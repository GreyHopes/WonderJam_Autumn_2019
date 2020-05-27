using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Line", menuName = "Dialogue/Line")]
[System.Serializable]
public class Line : DialogueElement
{
    [TextArea(2, 5)]
    public string text;
}
