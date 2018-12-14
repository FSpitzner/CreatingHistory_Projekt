using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// </summary>
public class LevelManager : MonoBehaviour 
{
    public static LevelManager instance;
    public bool mapOptained = false;
    public TMP_Reveal tmpReveal;
    public GameObject monologue;
    public GameObject fadeout;
    public WikiButton[] wikiButtons;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        fadeout.GetComponent<EventTrigger>().enabled = false;
        foreach(WikiButton w in wikiButtons)
        {
            w.Initialize();
        }

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