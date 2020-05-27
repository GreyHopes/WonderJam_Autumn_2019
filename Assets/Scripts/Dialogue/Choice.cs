using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R;

[System.Serializable]
[CreateAssetMenu(fileName = "New Choice", menuName = "Dialogue/Choice")]
public class Choice : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;

    public string targetWho;

    public whatEnum targetWhat = whatEnum.Attack;
    public float change;

    public enum whatEnum // your custom enumeration
    {
        Attack = S.DAMAGE,
        RateOfFire = S.ROF,
        Health = S.HP,
        Speed = S.SPEED,
        Range = S.RANGE,
        ProjectileSpeed = S.PROJECTILE_SPEED
    };

    public Conversation followUpConversation;
}
