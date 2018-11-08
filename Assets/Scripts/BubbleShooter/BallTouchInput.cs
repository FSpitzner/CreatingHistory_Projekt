using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        if (ball == null)
        {
            onTheWay = false;
            ball = Instantiate(ballPrefab, transform).GetComponent<Bubble>().CreateNewRandom();
        }
        else if (!onTheWay)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 startpos = Input.GetTouch(0).position;
                startpos.z = -10f;
                startPosition = Camera.main.ScreenToWorldPoint(startpos);
                startPosition.z = 0f;
                if (Vector3.Distance(new Vector3(ball.transform.position.x, ball.transform.position.y, 0f), startPosition) <= startDistance)
                {
                    line.SetPosition(0, startPosition);
                    line.SetPosition(1, startPosition);
                    Debug.Log("Touch Began at Pos: " + startPosition);
                    inputStarted = true;
                }
            }
            if (inputStarted)
            {
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
                    Debug.Log("Direction: " + direction);
                }
                else
                {
                    ball.PropellBall(direction.normalized);
                    inputStarted = false;
                    onTheWay = true;
                    line.SetPositions(new Vector3[2] { new Vector3(0, 0, 0), new Vector3(0, 0, 0) });
                }
            }
        }
    }
}
