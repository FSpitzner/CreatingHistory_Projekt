using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 
/// </summary>
public class ScoreCounter : MonoBehaviour 
{
    public static ScoreCounter instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreboard();
    }

    private void UpdateScoreboard()
    {
        scoreText.text = score.ToString();
    }
}