﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BubbleShooterManager))]
public class BallTouchInput : MonoBehaviour {

    public LineRenderer line;
    public RectTransform canvasTransform;
    public Bubble ball;
    public GameObject ballPrefab;
    public float startDistance = .5f;
    Vector3 startPosition;
    Vector2 direction;
    bool inputStarted = false;
    bool onTheWay = false;
    bool mouseInput = false;
    private BubbleShooterManager manager;

    private void Start()
    {
        manager = GetComponent<BubbleShooterManager>();
        ball = Instantiate(ballPrefab, transform).GetComponent<Bubble>().CreateNewRandom(manager.GetRemainingColors());
        line.material.color = ball.GetComponent<Image>().color;
    }

    private void Update()
    {
        if (ball == null)
        {
            onTheWay = false;
            bool[] remainingColors = manager.GetRemainingColors();
            bool colorsLeft = false;
            for(int i = 0; i < remainingColors.Length; i++)
            {
                if (remainingColors[i])
                    colorsLeft = true;
            }
            if (colorsLeft)
            {
                ball = Instantiate(ballPrefab, transform).GetComponent<Bubble>().CreateNewRandom(remainingColors);
                ball.gameObject.SetActive(true);
                line.material.color = ball.GetComponent<Image>().color;
                manager.DecreaseShots();
            }
            else
                manager.Win();

        }
        else if (!onTheWay)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                mouseInput = false;
                Vector3 startpos = Input.GetTouch(0).position;
                startpos.z = -10f;
                startPosition = Camera.main.ScreenToWorldPoint(startpos);
                startPosition.z = 0f;
                if (Vector3.Distance(new Vector3(ball.transform.position.x, ball.transform.position.y, 0f), startPosition) <= startDistance)
                {
                    line.SetPosition(0, startPosition);
                    line.SetPosition(1, startPosition);
                    //Debug.Log("Touch Began at Pos: " + startPosition);
                    inputStarted = true;
                }
            }else if (Input.GetMouseButtonDown(0))
            {
                mouseInput = true;
                Vector3 startpos = Input.mousePosition;
                startpos.z = -10f;
                startPosition = Camera.main.ScreenToWorldPoint(startpos);
                startPosition.z = 0f;
                if (Vector3.Distance(new Vector3(ball.transform.position.x, ball.transform.position.y, 0f), startPosition) <= startDistance)
                {
                    line.SetPosition(0, startPosition);
                    line.SetPosition(1, startPosition);
                    //Debug.Log("Touch Began at Pos: " + startPosition);
                    inputStarted = true;
                }
            }
            if (inputStarted)
            {
                if (!mouseInput)
                {
                    //Debug.Log("TouchInput");
                    if (Input.touchCount > 0)
                    {
                        Vector3 touchpos = Input.GetTouch(0).position;
                        touchpos.z = -10f;
                        //touchpos = new Vector3(touchpos.x * canvasTransform.localScale.x, touchpos.y * canvasTransform.localScale.y, touchpos.z * canvasTransform.localScale.z);
                        Vector3 worldpos = Camera.main.ScreenToWorldPoint(touchpos);
                        worldpos.z = 0f;
                        Vector3 point = worldpos - startPosition;
                        point = startPosition - point;
                        line.SetPosition(1, point);
                        direction = new Vector2(point.x - startPosition.x, point.y - startPosition.y);
                        //Debug.Log("Direction: " + direction);
                    }
                    else
                    {
                        ball.PropellBall(direction.normalized);
                        inputStarted = false;
                        onTheWay = true;
                        line.SetPositions(new Vector3[2] { new Vector3(0, 0, 0), new Vector3(0, 0, 0) });
                    }
                }
                else
                {
                    //Debug.Log("MouseInput");
                    if (Input.GetMouseButton(0))
                    {
                        Vector3 mousepos = Input.mousePosition;
                        mousepos.z = -10f;
                        Vector3 worldpos = Camera.main.ScreenToWorldPoint(mousepos);
                        worldpos.z = 0f;
                        Vector3 point = worldpos - startPosition;
                        point = startPosition - point;
                        line.SetPosition(1, point);
                        direction = new Vector2(point.x - startPosition.x, point.y - startPosition.y);
                        //Debug.Log("Direction: (" + direction.x + ", " + direction.y + ") | Point: (" + point.x + ", " + point.y + ") | StartPosition: (" + startPosition.x + ", " + startPosition.y + ")");
                    }
                    else
                    {
                        //Debug.Log("Shooting, Direction: " + direction.normalized);
                        ball.PropellBall(direction.normalized);
                        inputStarted = false;
                        onTheWay = true;
                        line.SetPositions(new Vector3[2] { new Vector3(0, 0, 0), new Vector3(0, 0, 0) });
                    }
                }
            }
        }
    }

    public void DestroyBall()
    {
        Destroy(ball.gameObject);
    }
}
