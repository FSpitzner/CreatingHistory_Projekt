using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WikiController : MonoBehaviour {

    public TextMeshProUGUI textfield;
    private WikiContent currentContent;

    public void SetContent(WikiContent wikiContent)
    {
        textfield.text = wikiContent.GetContent();
        currentContent = wikiContent;
    }

    public void Next()
    {
        if (currentContent != null && currentContent.next != null)
            SetContent(currentContent.next);
    }

    public void Previous()
    {
        Debug.Log("Previous = " + currentContent.previous);
        if (currentContent != null && currentContent.previous != null)
            SetContent(currentContent.previous);
    }
}
