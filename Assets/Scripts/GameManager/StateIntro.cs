using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIntro : State<GameManager>
{
    public StateIntro()
    {
        this.stateColor = Color.magenta;
    }

    public override void StartState()
    {
        GameManager.Instance.StateColor.color = this.stateColor;
        GameManager.Instance.BeginIntro();

        GameManager.Instance.OnIntroEnd += EndDialogue;
    }

    // Update is called once per frame
    public override void Update()
    {
    }

    public override void EndState()
    {

    }

    private void EndDialogue()
    {
        stateMachine.CurrentState = new StateWave();
    }
}
