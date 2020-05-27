using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cawotte.Toolbox;
using R;
using System;
using Cawotte.Toolbox.Audio;
using UnityEngine.InputSystem;

[System.Serializable]
public struct CharacterMapping
{
    public string name;
    public AlliedShip character;
}

public class GameManager : Singleton<GameManager>
{
    [Header("Game Entities")]
    public VirtualCursor Cursor;
    public ShipSelector ShipSelector;
    public CentralBase CentralBase;
    public CharacterMapping[] CharacterArrays;
    public Dictionary<string, AlliedShip> characters;

    public Action OnGameEnd;
    public Action OnPhaseTimerEnd;
    public Action OnDialogueEnd;
    public Action OnIntroEnd;

    [Header("Game Options")]
    public int startingMoney = 100;

    [Header("Debug")]
    public SpriteRenderer StateColor;

    [NonSerialized]
    public GameObject UpgradeMenu;
    
    [SerializeField]
    private int currentMoney;

    // private components
    private Controls controls;
    private int deadAllyCount;
    private float gamephaseTimer;

    private bool checkDeadWave;
    private bool gameHasEnded;
    private bool isUpgradeMenuOpen;

    private StateMachine<GameManager> gameState;

    private int waveCount = 0;

    private HUD hud;

    private float timer = 0f;
    private int enemyCount = 0;

    public Action<int> OnMoneyChange;
    public Action<float> OnTimerChange;
    public Action<int> OnWaveCountChange;

    private AudioSourcePlayer player;
    public int CurrentMoney
    {
        get
        {
            return currentMoney;
        }
        set
        {
            currentMoney = value;
            OnMoneyChange?.Invoke(value);
        }
    }

    public HUD Hud
    {
        get => hud;
        set => hud = value;
    }

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            OnTimerChange?.Invoke(value);
        }
    }

    public int WaveCount
    {
        get => waveCount;
        set
        {
            waveCount = value;
            OnWaveCountChange?.Invoke(value);
        }
    }

    public int EnemyCount
    {
        get => enemyCount;
        set => enemyCount = value;
    }

    public bool CheckDeadwave
    {
        get => checkDeadWave;
        set => checkDeadWave = value;
    }

    public AudioSourcePlayer Player => player;

    private void Awake()
    {
        // initialise variables
        controls = new Controls();

        player = gameObject.AddComponent<AudioSourcePlayer>();
    }

    private void Start()
    {
        characters = new Dictionary<string, AlliedShip>();

        foreach (CharacterMapping mapping in CharacterArrays)
        {
            characters.Add(mapping.name, mapping.character);
        }
        gameState = new StateMachine<GameManager>(new StateIntro(), this);
        currentMoney = startingMoney;

        AudioManager.Instance.PlayMusic("main_music");
        Cursor.gameObject.SetActive(true);
        UpgradeMenu.SetActive(false);
    }

    private void OnEnable()
    {
        for (int i = 0; i < CharacterArrays.Length; i++)
        {
            CharacterArrays[i].character.OnAllyDeath += OnAllyDeath;
        }
        CentralBase.OnDeath += OnBaseDeath;

        // input
        controls.GameControls.Enable();
        controls.GameControls.ToggleUpgradeMenu.performed += OnToggleUpgradeMenu;

    }

    private void OnDisable()
    {
        for (int i = 0; i < CharacterArrays.Length; i++)
        {
            CharacterArrays[i].character.OnAllyDeath -= OnAllyDeath;
        }
        CentralBase.OnDeath -= OnBaseDeath;

        controls.GameControls.Disable();
        controls.GameControls.ToggleUpgradeMenu.performed -= OnToggleUpgradeMenu;
    }

    private void Update()
    {
        gameState.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RespawnAllies();
        }

    }

    private void RespawnAllies()
    {
        for (int i = 0; i < CharacterArrays.Length; i++)
        {
            CharacterArrays[i].character.Reinitialize();
        }
    }

    public void InitializeHUD()
    {
        OnMoneyChange += hud.SetCreditsUI;
        OnTimerChange += hud.SetTextTimer;

        OnWaveCountChange += hud.SetTextRound;
        //MapManager.Instance.EnemySpawner.OnWaveStart += (wave) => hud.SetTextRound(wave.NumWave);

        hud.SetCreditsUI(currentMoney);
        hud.SetTextTimer(timer);

        //hud.SetTextRound(MapManager.Instance.EnemySpawner.CurrentWave.NumWave);
        hud.SetTextRound(WaveCount);
    }

    public void OnEnemyDeath(int value)
    {
        CurrentMoney += value;
    }

    public void OnAllyDeath(int allyID)
    {
        deadAllyCount++;
        if (deadAllyCount >= CharacterArrays.Length && !gameHasEnded)
        {
            GameEnd();
        }
    }

    public void OnBaseDeath()
    {
        if (!gameHasEnded)
        {
            GameEnd();
        }
    }

    public void BeginDialogue()
    {
        if(gameState.CurrentState is StateDialog)
        {
            OnDialogueEnd?.Invoke();
        }
        
        //DialogueManager.Instance.InitializeAndShow();
    }

    public void EndDialogue()
    {
        if(gameState.CurrentState is StateDialog)
        {
            OnDialogueEnd?.Invoke();
        }
    }

    public void BeginIntro()
    {
        DialogueManager.Instance.ShowIntro();
    }

    public void EndIntro()
    {
        if (gameState.CurrentState is StateIntro)
        {
            OnIntroEnd?.Invoke();
        }
    }


    public void BeginUpgrade()
    {
        SetUpgradeMenuOpen(false);
        Hud.StartFlashUpgrade();
    }

    public void EndUpgrade()
    {
        SetUpgradeMenuOpen(false);
        Hud.StopFlashUpgrade();
    }

    public void BeginWave()
    {

    }

    #region Phase Timer

    public void SetPhaseTimer(float phaseTime)
    {
        gamephaseTimer = phaseTime;
    }

    public void UpdatePhaseTimer()
    {
        gamephaseTimer -= Time.deltaTime;
        Hud.UpdateUpgradeTimer(gamephaseTimer);
        if (gamephaseTimer <= 0)
        {
            if (OnPhaseTimerEnd != null) OnPhaseTimerEnd();
        }
    }

    #endregion

    private void GameEnd()
    {
        Debug.Log("GAME OVER");
        if (OnGameEnd != null) OnGameEnd();
        gameHasEnded = true;
    }
    private void OnToggleUpgradeMenu(InputAction.CallbackContext obj)
    {
        SetUpgradeMenuOpen(!isUpgradeMenuOpen);
    }

    public void SetUpgradeMenuOpen(bool isOpen)
    {
        Debug.Log("setting open to :" + isOpen + " was : " + isUpgradeMenuOpen);
        if (gameState.CurrentState is StateUpgrade)
        {
            Debug.Log("switching");
            isUpgradeMenuOpen = isOpen;
            Cursor.gameObject.SetActive(!isUpgradeMenuOpen);
            UpgradeMenu.SetActive(isUpgradeMenuOpen);
        }
    }

    public bool CanAfford(int cost)
    {
        return currentMoney >= cost;
    }

    public void Pay(int cost)
    {
        CurrentMoney -= cost;
    }

    public void ProcessChoice(Choice choice)
    {
        if (!choice.targetWho.Equals("All") && characters.ContainsKey(choice.targetWho))
        {
            int toModify = (int)choice.targetWhat;
            Character character = characters[choice.targetWho];
            character.UpgradeStats(toModify);
        }

        if (choice.targetWho.Equals("All"))
        {
            int toModify = (int)choice.targetWhat;
            foreach (Character character in characters.Values)
            {
                character.UpgradeStats(toModify);
            }

        }

        if (choice.targetWho.Equals("All"))
        {
            int toModify = (int)choice.targetWhat;
            foreach (Character character in characters.Values)
            {
                character.UpgradeStats(toModify);
            }
        }

        if (choice.targetWho.Equals("Money"))
        {
            int toModify = (int)choice.targetWhat;

            if (toModify == S.MONEY)
            {
                CurrentMoney += (int)choice.change;
            }
            else
            {
                Debug.Log("Silently ignored money choice " + choice.ToString());
            }
        }
    }

}
