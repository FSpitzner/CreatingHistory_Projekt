using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEnd : MonoBehaviour {

    public UnityEvent response;

	public void SetAnimationComplete()
    {
        response.Invoke();
    }
}
