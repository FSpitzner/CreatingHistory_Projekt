using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Wiki Content")]
public class WikiContent : ScriptableObject {
    [TextArea(2,10)]
    public string content;
    public WikiContent previous;
    public WikiContent next;

    public string GetContent()
    {
        string con = content.Replace('#', '\n');
        con = con.Replace('~', '\t');
        return con;
    }
}
