using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
/// 
[RequireComponent(typeof(Rigidbody2D))]
public class Bubble : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] float power = 5f;
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
        rb.AddRelativeForce(new Vector2(0, 1) * power, ForceMode2D.Impulse);
	}
	#endregion
	
	
	
	#region Public Functions
	
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}