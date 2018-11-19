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
    }

    public void SetStriche()
    {
        hasStriche = true;
    }

    public void SetMenhir()
    {
        hasMenhir = true;
    }

    public void CheckProgress()
    {
        if (hasAxt && hasStriche && hasMenhir)
            finishEvent.Invoke();
    }
}