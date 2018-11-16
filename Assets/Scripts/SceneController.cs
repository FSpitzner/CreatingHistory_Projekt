using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SceneController : MonoBehaviour 
{

    #region Variable Declarations
    // Serialized Fields
    [SerializeField] static bool firstEncounter = true;
    [SerializeField] MonologueContent firstMonologue;
	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        firstEncounter = false;
        StartMonologue(firstMonologue);
	}
	#endregion
	
	
	
	#region Public Functions
    public void StartMonologue(MonologueContent content)
    {
        LevelManager.instance.StartMonologue(content);
    }
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}