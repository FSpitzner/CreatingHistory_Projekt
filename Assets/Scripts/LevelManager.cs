using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class LevelManager : MonoBehaviour 
{
    public static LevelManager instance;
    public bool mapOptained = false;
    public TMP_Reveal tmpReveal;
    public GameObject monologue;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartMonologue(MonologueContent content)
    {
        monologue.SetActive(true);
        tmpReveal.RevealText(content);
    }

    public void StartMonologue(MonologueContent content, GameEvent finishEvent)
    {
        monologue.SetActive(true);
        tmpReveal.RevealText(content, finishEvent);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}