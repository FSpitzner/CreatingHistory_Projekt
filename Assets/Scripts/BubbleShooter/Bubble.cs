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
        //rb.AddRelativeForce(new Vector2(0, 1) * power * BubbleShooterManager.instance.canvasTransform.localScale.y, ForceMode2D.Impulse);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!!!");
        if(collision.collider.tag == "Leaf")
        {
            if(collision.collider.GetComponent<Leaf>().color == color)
            {
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

    public Bubble CreateNewRandom()
    {
        color = (Leaf.Color)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Leaf.Color)).Length);
        switch (color)
        {
            case Leaf.Color.Green:
                image.color = greenColor;
                break;
            case Leaf.Color.Blue:
                image.color = blueColor;
                break;
            case Leaf.Color.White:
                image.color = whiteColor;
                break;
            case Leaf.Color.Yellow:
                image.color = yellowColor;
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