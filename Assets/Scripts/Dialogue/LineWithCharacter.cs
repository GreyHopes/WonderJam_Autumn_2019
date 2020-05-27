using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Line with character", menuName = "Dialogue/Line with character")]
public class LineWithCharacter : Line
{
    public string characterName;
    public Sprite characterSprite;
}
