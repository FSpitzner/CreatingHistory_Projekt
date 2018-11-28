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
    bool firstEncounter = true;
    [SerializeField] MonologueContent firstMonologue;
    [SerializeField] GameEvent firstMonologFinishEvent;
    [SerializeField] GameObject backButton;
    [SerializeField] bool showBackButtonOnSecEncounter;
	// Private
	
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
        if (firstEncounter)
        {
            firstEncounter = false;
            if (firstMonologue != null && firstMonologFinishEvent == null)
                StartMonologue(firstMonologue);
            if (firstMonologue != null && firstMonologFinishEvent != null)
                StartMonologue(firstMonologue, firstMonologFinishEvent);
        }
        else if (showBackButtonOnSecEncounter)
            backButton.SetActive(true);
	}
	#endregion
	
	
	
	#region Public Functions
    public void StartMonologue(MonologueContent content)
    {
        LevelManager.instance.StartMonologue(content);
    }

    public void StartMonologue(MonologueContent content, GameEvent finishEvent)
    {
        LevelManager.instance.StartMonologue(content, finishEvent);
    }
	#endregion
	
	
	
	#region Private Functions

	#endregion
	
	
	
	#region Coroutines
	
	#endregion
}