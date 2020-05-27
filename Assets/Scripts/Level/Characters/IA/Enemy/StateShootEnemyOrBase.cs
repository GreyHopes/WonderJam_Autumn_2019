using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShootEnemyOrBase : State<Character>
{
    public Character target = null;

    public override void StartState()
    {
        stateMachine.Subject.EnemySensor.OnLoseOfSight += LoseSightOfTarget;

        this.stateColor = Color.magenta;
        
        target = GetFirstTarget();
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
            stateMachine.CurrentState = new StateGoToBase();
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
            //Search for the base
            foreach (Character sighted in stateMachine.Subject.EnemySensor.SightedObjects)
            {
                if (sighted is CentralBase)
                {
                    return sighted;
                }
            }
            //else enemy ship
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
