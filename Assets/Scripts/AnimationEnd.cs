using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour {

    public GameObject ui;
    public GameObject border;

	public void SetAnimationComplete()
    {
        ui.SetActive(true);
        border.SetActive(true);
    }
}
