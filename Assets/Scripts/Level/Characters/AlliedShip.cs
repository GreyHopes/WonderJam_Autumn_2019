using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cawotte.Toolbox.Audio;
public class AlliedShip : Character
{
    [Header("Allied Ship Components")]
    [SerializeField] private GameObject selectionAura;
    [SerializeField] private SpriteRenderer shipRenderer;
    [SerializeField] private Transform respawnPoint;

    [Header("Allied Ship Info")]
    //DISABLE FEATURE
    [SerializeField] private bool enableCursor = true;

    public Action<int> OnAllyDeath;

    private VirtualCursor cursor;
    private bool isSelected;

    private void Awake()
    {
        base.Awake();
        if (enableCursor)
        {
            if (cursor == null) cursor = FindObjectOfType<VirtualCursor>();
        }

        if (shipRenderer == null) shipRenderer = GetComponentInChildren<SpriteRenderer>();

        
        blowUpSound = "destruction_ally";
        offset = -90;
    }

    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        if (cursor != null)
            cursor.OnClick += OnCursorClick;

        stateMachine = new StateMachine<Character>(new StateShootFirstEnemy(), this);
    }

    private void OnDisable()
    {
        if (cursor != null)
            cursor.OnClick -= OnCursorClick;
    }

    // Update is called once per frame
    private void Update()
    {
        base.Update();
        
        stateMachine.Update();
    }

    public override void TakeDamage(Character source, int damage)
    {
        base.TakeDamage(source, damage);
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        // warn everyone
        if (OnAllyDeath != null) OnAllyDeath(GetInstanceID());

        StopMovement();
        gameObject.SetActive(false);
        //player.PlaySound("destruction_ally");
    }

    public void Reinitialize()
    {
        // if dead, respawn
        if (currentHealth <= 0)
        {
            // do some actual respawn code (state machine?)
            shipRenderer.enabled = true;

            // move it to its spawn position
            transform.position = respawnPoint.position;

            // reactivate object
            gameObject.SetActive(true);

            // reactivate everything and make it blink
            StartCoroutine(RespawnBlink());
        }
        CurrentHealth = MaxHealth;
    }

    public void OrderMoveTo(Vector3 pos)
    {
        stateMachine.CurrentState = new StateMoveTo(pos);
    }
    
    #region Selection
    public void OnCursorClick(Vector2 worldPos)
    {
        if (isSelected)
        {
            MoveTo(worldPos);
        }
    }

    public void OnSelectShip(int shipID)
    {
        isSelected = shipID == this.GetInstanceID();

        // handle other select boolean things here, like a selected aura and etc.
        selectionAura.SetActive(isSelected);
    }
    #endregion

    private IEnumerator RespawnBlink()
    {
        float elapsedTime = 0;
        float blinkDuration = 1.5f;
        float blinkDelay = 0.064f;
        Color shipColor = shipRenderer.color;
        while (elapsedTime < blinkDuration)
        {
            // dim the sprite
            shipColor.a = 0.6f;
            shipRenderer.color = shipColor;
            elapsedTime += blinkDelay;
            yield return new WaitForSeconds(blinkDelay);

            // recolor the sprite
            shipColor.a = 1f;
            shipRenderer.color = shipColor;
            elapsedTime += blinkDelay;
            yield return new WaitForSeconds(blinkDelay);
        }
    }
}
