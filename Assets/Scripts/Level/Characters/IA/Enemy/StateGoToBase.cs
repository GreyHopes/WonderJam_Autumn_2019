using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGoToBase : State<Character> 
{
    private Vector3 basePosition;

    public StateGoToBase()
    {
        this.basePosition = MapManager.Instance.CentralBase.Position;

        this.stateColor = Color.cyan;
    }
    
    public override void StartState()
    {
        stateMachine.Subject.MoveTo(basePosition);
        
        //Interrupts
        stateMachine.Subject.EnemySensor.OnSight += 
            (var) => AttackClosest();
    }

    // Update is called once per frame
    public override void Update()
    {

        if (!stateMachine.Subject.IsMoving)
        {
            stateMachine.CurrentState = new StateShootEnemyOrBase();
        }
    }

    public override void EndState()
    {
        stateMachine.Subject.StopMovement();
        
        
        //Interrupts
        stateMachine.Subject.EnemySensor.OnSight -= 
            (var) => AttackClosest();
    }

    public void AttackClosest()
    {
        stateMachine.CurrentState = new StateShootEnemyOrBase();
    }
}
