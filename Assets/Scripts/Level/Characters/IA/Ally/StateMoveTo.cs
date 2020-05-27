using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMoveTo : State<Character> 
{
    
    private Vector3 target;
    private Vector3 centerTarget;

    public StateMoveTo(Vector3 target)
    {
        this.target = target;
        this.centerTarget = MapManager.Instance.LevelMap.GetTileAt(target).CenterWorld;

        this.stateColor = Color.blue;
    }
    
    public override void StartState()
    {
        //Get first target
        stateMachine.Subject.MoveTo(target);
        
    }

    // Update is called once per frame
    public override void Update()
    {

        if (!stateMachine.Subject.IsMoving)
        {
            stateMachine.CurrentState = new StateShootFirstEnemy();
        }
    }

    public override void EndState()
    {
        stateMachine.Subject.StopMovement();
    }

}
