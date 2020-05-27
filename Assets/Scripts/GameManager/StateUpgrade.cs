using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUpgrade : State<GameManager>
{
    private float upgradeTime = 15f;

    public StateUpgrade()
    {
        this.stateColor = Color.yellow;
    }
    
    public override void StartState()
    {
        GameManager.Instance.BeginUpgrade();

        GameManager.Instance.StateColor.color = this.stateColor;

        // Start timer
        GameManager.Instance.SetPhaseTimer(upgradeTime);       

        // Listen for timer end
        GameManager.Instance.OnPhaseTimerEnd += OnTimerEnd;
    }

    // Update is called once per frame
    public override void Update()
    {
        GameManager.Instance.UpdatePhaseTimer();
    }

    public override void EndState()
    {
    }

    private void OnTimerEnd()
    {
        // Force close upgrade menu
        GameManager.Instance.EndUpgrade();

        // Switch to wave state
        stateMachine.CurrentState = new StateWave();
    }
}
