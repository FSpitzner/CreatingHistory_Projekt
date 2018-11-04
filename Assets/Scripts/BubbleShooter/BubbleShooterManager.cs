using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShooterManager : MonoBehaviour {

    public static BubbleShooterManager instance;
    public RectTransform canvasTransform;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
