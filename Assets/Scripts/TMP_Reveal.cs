using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TMP_Reveal : MonoBehaviour {

    public TextMeshProUGUI textMesh;
    int counter = 0;
    int totalVisibleCharacters;
    MonologueContent content;
    public EventTrigger nextTrigger;
    public EventTrigger deactivateTrigger;
    public float revealSpeed = 0.05f;

    private GameEvent finishEvent = null;

    private void Start()
    {
        textMesh.maxVisibleCharacters = 0;
        nextTrigger.enabled = false;
        deactivateTrigger.enabled = false;
    }

    private void Reveal()
    {
        int visibleCount = counter % (totalVisibleCharacters + 1);
        textMesh.maxVisibleCharacters = visibleCount;

        if(visibleCount < totalVisibleCharacters)
        {
            counter += 1;
            Invoke("Reveal", revealSpeed);
        }
        else
        {
            if (content.next != null)
                nextTrigger.enabled = true;
            else
                deactivateTrigger.enabled = true;
        }
    }

    public void RevealText(MonologueContent content)
    {
        this.content = content;
        textMesh.text = content.content;
        counter = 0;
        totalVisibleCharacters = textMesh.textInfo.characterCount;
        Reveal();
    }

    public void RevealText(MonologueContent content, GameEvent finishEvent)
    {
        this.finishEvent = finishEvent;
        this.content = content;
        textMesh.text = content.content;
        counter = 0;
        totalVisibleCharacters = textMesh.textInfo.characterCount;
        Reveal();
    }

    public void NextContent()
    {
        RevealText(content.next);
    }

    private void EnableEventTrigger()
    {
        GetComponent<EventTrigger>().enabled = true;
    }

    public void DisableNextTrigger()
    {
        nextTrigger.enabled = false;
    }
    public void DisableDeactivateTrigger()
    {
        deactivateTrigger.enabled = false;
        if (finishEvent != null)
        {
            finishEvent.Raise();
            finishEvent = null;
        }
    }

    public void SpeedUpReveal()
    {
        revealSpeed = revealSpeed / 2;
    }
    public void SlowDownRevealSpeed()
    {
        revealSpeed = 0.05f;
    }
}
