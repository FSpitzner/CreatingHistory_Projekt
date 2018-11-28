using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMonologueEvent : MonoBehaviour {

    public MonologueContent monologue;
    public GameEvent gameEvent;

	public void ButtonPressed()
    {
        LevelManager.instance.StartMonologue(monologue, gameEvent);
    }
}
