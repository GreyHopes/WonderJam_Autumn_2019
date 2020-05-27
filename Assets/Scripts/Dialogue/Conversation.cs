using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation",menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public DialogueElement[] elementsQueue;
}
