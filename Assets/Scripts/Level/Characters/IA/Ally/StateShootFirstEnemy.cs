using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShootFirstEnemy : State<Character> 
{

    public Character target = null;

    public override void StartState()
    {
        //Get first target
        stateMachine.Subject.EnemySensor.OnLoseOfSight += LoseSightOfTarget;

        this.stateColor = Color.red;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (target != null)
        {
            stateMachine.Subject.TryShootAt(target.Position);
        }
        else
        {
            target = GetFirstTarget();
        }
    }

    public override void EndState()
    {
        stateMachine.Subject.EnemySensor.OnLoseOfSight -= LoseSightOfTarget;
    }

    private Character GetFirstTarget()
    {
        if (stateMachine.Subject.EnemySensor.SightedObjects.Count > 0)
        {
            return stateMachine.Subject.EnemySensor.SightedObjects[0];
        }
        else
        {
            return null;
        }
    }
    
    private void LoseSightOfTarget(Character characterLoseSightOf)
    {
        if (characterLoseSightOf.Equals(target))
        {
            target = GetFirstTarget();
        }
    }
    
}
