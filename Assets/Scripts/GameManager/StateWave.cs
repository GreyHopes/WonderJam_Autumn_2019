using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWave : State<GameManager>
{
    private float characterHealthBonus = 0.05f;
    private float baseHealthBonus = 0.1f;
    private float waveScaleBonus = 1.1f;

    private bool timerDialogIsEnabled = false;
    private float timerDialog = 4f;
    
    public StateWave()
    {
        this.stateColor = Color.grey;
    }
    
    public override void StartState()
    {
        Debug.Log("Start Wave State");
        GameManager.Instance.StateColor.color = this.stateColor;

        GameManager.Instance.WaveCount++;
        MapManager.Instance.EnemySpawner.GenerateAndStartWave(GameManager.Instance.WaveCount);
        
        //Listen for end of Wave
        MapManager.Instance.EnemySpawner.OnWaveEnd += EndWave;
        //Listen for game end
        GameManager.Instance.OnGameEnd += OnGameEnd;


        timerDialogIsEnabled = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        //timer is running
        GameManager.Instance.Timer += Time.deltaTime;

        if (timerDialogIsEnabled)
        {
            timerDialog -= Time.deltaTime;
            if (timerDialog <= 0f)
            {
                stateMachine.CurrentState = new StateUpgrade();
            }
        }
    }

    public override void EndState()
    {
        //Listen for end of Wave
        MapManager.Instance.EnemySpawner.OnWaveEnd -= EndWave;
        //Listen for game end
        GameManager.Instance.OnGameEnd -= OnGameEnd;
    }

    private void OnGameEnd()
    {
        stateMachine.CurrentState = new StateEndGame();
    }

    private void EndWave(Wave wave)
    {
        //compute bonus currency     
        float bonusCurrency = 0;
        for (int i = 0; i < GameManager.Instance.CharacterArrays.Length; i++)
        {
            if (GameManager.Instance.CharacterArrays[i].character.CurrentHealth > 0)
            {
                bonusCurrency += GameManager.Instance.CharacterArrays[i].character.CurrentHealth * characterHealthBonus;
            }
        }
        bonusCurrency += GameManager.Instance.CentralBase.CurrentHealth * baseHealthBonus;

        //scale bonus currency
        bonusCurrency *= GameManager.Instance.WaveCount * waveScaleBonus;

        GameManager.Instance.CurrentMoney += Mathf.RoundToInt(bonusCurrency);

        timerDialogIsEnabled = true;
    }
}