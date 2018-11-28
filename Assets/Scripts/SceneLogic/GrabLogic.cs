using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabLogic : MonoBehaviour {

    public UnityEvent finishEvent;
    public bool ritus = false;
    public bool beilagen = false;

    public void SetRitus()
    {
        ritus = true;
        CheckBools();
    }

    public void SetBeilagen()
    {
        beilagen = true;
        CheckBools();
    }

    private void CheckBools()
    {
        if (ritus && beilagen)
            finishEvent.Invoke();
    }
}
