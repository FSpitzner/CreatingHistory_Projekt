using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizController : MonoBehaviour {

    [Header("Quiz Settings")]
    public TextMeshProUGUI questionLabel;
    public TextMeshProUGUI answer1ButtonLabel;
    public TextMeshProUGUI answer2ButtonLabel;
    public TextMeshProUGUI answer3ButtonLabel;
    public TextMeshProUGUI answer4ButtonLabel;
    public Question[] questions;
    [Range(0, 1)]
    public float correctAnswersPercentNeeded;
    [Space]
    [Header("General Settings")]
    public MonologueContent quizWon;
    public GameEvent quizWonEvent;
    public MonologueContent quizLost;
    public GameEvent quizLostEvent;
    private bool[] answers;
    private int currentQuestion = 0;

    private void Start()
    {
        if (questions.Length != 0)
        {
            answers = new bool[questions.Length];
            Question question = questions[0];
            questionLabel.text = question.GetQuestion();
            answer1ButtonLabel.text = question.answer1;
            answer2ButtonLabel.text = question.answer2;
            answer3ButtonLabel.text = question.answer3;
            answer4ButtonLabel.text = question.answer4;
        }
    }

    public void NextQuestion()
    {
        if(questions.Length <= currentQuestion + 1)
        {
            QuizOver();
            return;
        }
        currentQuestion += 1;
        Question nextQuestion = questions[currentQuestion];
        questionLabel.text = nextQuestion.GetQuestion();
        answer1ButtonLabel.text = nextQuestion.answer1;
        answer2ButtonLabel.text = nextQuestion.answer2;
        answer3ButtonLabel.text = nextQuestion.answer3;
        answer4ButtonLabel.text = nextQuestion.answer4;
    }

    public void AnswerGiven(int buttonNumber)
    {
        answers[currentQuestion] = questions[currentQuestion].CheckAnswer(buttonNumber);
        NextQuestion();
    }

    private void QuizOver()
    {
        int rightAnswers = 0;
        foreach(bool b in answers)
        {
            if (b)
                rightAnswers += 1;
        }
        //Debug.Log("Testing percentage: " + (((float)rightAnswers / (float)(questions.Length))>=correctAnswersPercentNeeded));
        if((float)rightAnswers/(float)(questions.Length) >= correctAnswersPercentNeeded)
        {
            Debug.Log("Won");
        }
        else
        {
            LevelManager.instance.StartMonologue(quizLost, quizLostEvent);
        }
    }
}
