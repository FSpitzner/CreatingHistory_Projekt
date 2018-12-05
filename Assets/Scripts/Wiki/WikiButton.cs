using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class WikiButton : MonoBehaviour {

    public TextMeshProUGUI text;
    public EventTrigger eventTrigger;
    public Color enabledColor;

    private void Start()
    {
        eventTrigger.enabled = false;
    }

    public void Enable()
    {
        eventTrigger.enabled = true;
        text.color = enabledColor;
    }

}
