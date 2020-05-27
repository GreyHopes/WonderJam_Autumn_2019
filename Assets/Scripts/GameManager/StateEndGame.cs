using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEndGame : State<GameManager>
{
    public StateEndGame()
    {
        stateColor = Color.red;
    }
    public override void StartState()
    {
        GameManager.Instance.StateColor.color = this.stateColor;

        // Start end game screen

        // Listen for buttons to go back to main menu

    }

    public override void Update()
    {
    }

    private void OnAnyButton()
    {
        // Return to main menu
    }
}
