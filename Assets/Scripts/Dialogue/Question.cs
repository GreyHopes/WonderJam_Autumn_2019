using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Dialogue/Question")]
public class Question : DialogueElement
{
    [TextArea(2, 5)]
    public string text;

    public Choice[] choices;
}
