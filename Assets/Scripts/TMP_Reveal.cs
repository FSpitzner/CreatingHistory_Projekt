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
            Invoke("Reveal", 0.05f);
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
    }
}
