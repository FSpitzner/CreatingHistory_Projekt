using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject {

    [TextArea(2,4)]
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    public int rightAnswer;

    public bool CheckAnswer(int playerAnswer)
    {
        Debug.Log("Player Answered: " + playerAnswer + " | Right Answer: " + rightAnswer);
        if (playerAnswer == rightAnswer)
            return true;
        return false;
    }

    public string GetQuestion()
    {
        string que;
        que = question.Replace('#', '\n');
        return que;
    }
}
