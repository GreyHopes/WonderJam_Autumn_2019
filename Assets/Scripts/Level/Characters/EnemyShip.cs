using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cawotte.Toolbox.Audio;
public class EnemyShip : Character
{
    private void Awake()
    {
        base.Awake();
        blowUpSound = "destruction_ennemi";
    }
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
        stateMachine = new StateMachine<Character>(new StateGoToBase(), this);
        
        OnDeath += () => GameManager.Instance.EnemyCount--;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
        stateMachine.Update();
    }

    protected override void MoveToward(Vector3 pos)
    {
        base.MoveToward(pos);
        animator.SetBool("isMoving", true);
    }

    public override void StopMovement()
    {
        base.StopMovement();
        animator.SetBool("isMoving", false);
    }

    
}
