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

    public string GetAnswer(int number)
    {
        string answer;
        switch (number)
        {
            case 1:
                answer = answer1.Replace('#', '\n');
                return answer;
            case 2:
                answer = answer2.Replace('#', '\n');
                return answer;
            case 3:
                answer = answer3.Replace('#', '\n');
                return answer;
            default:
                Debug.LogError("Trying to get an Answer with Number <= 0 || >= 4");
                return null;
        }
    }
}
