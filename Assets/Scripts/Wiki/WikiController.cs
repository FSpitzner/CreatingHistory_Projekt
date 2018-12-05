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
    }

    public void Next()
    {
        if (currentContent.next != null)
            SetContent(currentContent.next);
    }

    public void Previous()
    {
        if (currentContent.previous != null)
            SetContent(currentContent.previous);
    }
}
