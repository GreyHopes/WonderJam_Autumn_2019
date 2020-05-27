using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDialog : State<GameManager>
{
    public StateDialog()
    {
        this.stateColor = Color.blue;
    }
    
    public override void StartState()
    {
        GameManager.Instance.StateColor.color = this.stateColor;

        GameManager.Instance.BeginDialogue();

        GameManager.Instance.OnDialogueEnd += EndDialogue;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public override void EndState()
    {
        
    }

    private void EndDialogue()
    {
        stateMachine.CurrentState = new StateUpgrade();
    }
}
