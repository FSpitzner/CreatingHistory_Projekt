using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/MonologueContent")]
public class MonologueContent : ScriptableObject 
{
    [TextArea(2,5)]
    public string content;
    public MonologueContent next;
}