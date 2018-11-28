using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WikiController : MonoBehaviour {

    public TextMeshProUGUI textfield;

    public void SetContent(WikiContent wikiContent)
    {
        textfield.text = wikiContent.content;
    }
}
