using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
/// 
[RequireComponent(typeof(Rigidbody2D))]
public class Bubble : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] Image image;
    [SerializeField] float power = 5f;
    [SerializeField] Leaf.Color color;
    [Space]
    [SerializeField] Color greenColor;
    [SerializeField] Color blueColor;
    [SerializeField] Color whiteColor;
    [SerializeField] Color yellowColor;
    // Private
    private ScoreCounter scoreCounter;
    private Rigidbody2D rb;
    #endregion



    #region Public Properties

    #endregion



    #region Unity Event Functions
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start () 
	{
        scoreCounter = ScoreCounter.instance;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!!!");
        if(collision.collider.tag == "Leaf")
        {
            if(collision.collider.GetComponent<Leaf>().color == color)
            {
                scoreCounter.IncreaseScore(collision.collider.GetComponent<Leaf>().points);
                Destroy(collision.gameObject);
            }
        }
    }
    #endregion



    #region Public Functions
    public void PropellBall(Vector2 direction)
    {
        rb.AddRelativeForce(direction * power * BubbleShooterManager.instance.canvasTransform.localScale.y, ForceMode2D.Impulse);
    }

    public Bubble CreateNewRandom(bool[] remainingColors)
    {
        color = (Leaf.Color)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Leaf.Color)).Length);
        switch (color)
        {
            case Leaf.Color.Blue:
                if (remainingColors[0])
                    image.color = blueColor;
                else
                    return CreateNewRandom(remainingColors);
                break;
            case Leaf.Color.Green:
                if (remainingColors[1])
                    image.color = greenColor;
                else
                    return CreateNewRandom(remainingColors);
                break;
            case Leaf.Color.White:
                if (remainingColors[2])
                    image.color = whiteColor;
                else
                    return CreateNewRandom(remainingColors);
                break;
            case Leaf.Color.Yellow:
                if (remainingColors[3])
                    image.color = yellowColor;
                else
                    return CreateNewRandom(remainingColors);
                break;
            default: break;
        }
        return this;
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}