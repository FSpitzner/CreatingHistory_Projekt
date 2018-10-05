using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    public RectTransform parentObject;
    public float speed = 0.1f;
    public float swipeCooldown = 3f;
    public float swipeDistancePixel = 1920;
    private bool swiping = false;
    private float timer;
    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(timer >= swipeCooldown)
        {
            swiping = false;
            timer = 0f;
        }
        if (!swiping)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                if (touchDeltaPosition.x > 1)
                {
                    SwipeRight();
                    swiping = true;
                }
                else if (touchDeltaPosition.x < -1)
                {
                    SwipeLeft();
                    swiping = true;
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void SwipeRight()
    {
        LeanTween.move(gameObject, new Vector3(transform.position.x + swipeDistancePixel * parentObject.localScale.x, transform.position.y, transform.position.z), 0.5f).setEaseInOutCubic();
    }

    private void SwipeLeft()
    {
        LeanTween.move(gameObject, new Vector3(transform.position.x - swipeDistancePixel * parentObject.localScale.x, transform.position.y, transform.position.z), 0.5f).setEaseInOutCubic();
    }
}
