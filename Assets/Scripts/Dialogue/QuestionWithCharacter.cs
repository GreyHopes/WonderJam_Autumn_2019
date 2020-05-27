using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question with character", menuName = "Dialogue/Question with character")]
public class QuestionWithCharacter : Question
{
    public string characterName;
    public Sprite characterSprite;
}
