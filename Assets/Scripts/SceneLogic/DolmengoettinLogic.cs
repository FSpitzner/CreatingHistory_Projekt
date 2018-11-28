using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 
/// </summary>
public class DolmengoettinLogic : MonoBehaviour 
{
    public UnityEvent finishEvent;
    public bool hasAxt;
    public bool hasStriche;
    public bool hasMenhir;
    
    
    public void SetAxt()
    {
        hasAxt = true;
        CheckProgress();
    }

    public void SetStriche()
    {
        hasStriche = true;
        CheckProgress();
    }

    public void SetMenhir()
    {
        hasMenhir = true;
        CheckProgress();
    }

    public void CheckProgress()
    {
        if (hasAxt && hasStriche && hasMenhir)
            finishEvent.Invoke();
    }
}