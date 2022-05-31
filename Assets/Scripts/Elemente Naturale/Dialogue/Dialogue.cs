using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string title;

    [TextArea(2,10)]
    public string[] sentences;

}
