using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Cawotte.Toolbox.Audio;
using Cawotte.Toolbox.Pathfinding;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using R;
using Cawotte.Toolbox.Audio;

[System.Serializable]
public class Character : MonoBehaviour
{
    protected AudioSourcePlayer player;

    [Header("Components")]
    [SerializeField] 
    private Sensor sensor;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject explosionPrefab;

    [Header("Parameters")] 
    [SerializeField] protected int maxHealth = 5;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rateOfFire = 1f;
    [SerializeField] private float range = 1f;
    [SerializeField] private float damage = 1;
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] protected float offset = -90f;

    [SerializeField] protected int moneyGainedOnDeath = 0;
    [Header("Upgrade stats")]
    [SerializeField] protected CharacterUpgrade maxHealthUpgrade;
    [SerializeField] private CharacterUpgrade speedUpgrade;
    [SerializeField] private CharacterUpgrade rateOfFireUpgrade;
    [SerializeField] private CharacterUpgrade rangeUpgrade;
    [SerializeField] private CharacterUpgrade damageUpgrade;
    [SerializeField] private CharacterUpgrade projectileSpeedUpgrade;

    [Header("Info")]
    [SerializeField][ReadOnly]
    private Vector2Int currentGridPos;
    [SerializeField][ReadOnly] protected int currentHealth;
    //Movements
    [SerializeField][ReadOnly]
    private bool isMoving = false;

    private TilePath currentPath = null; 
    private TileNode targetCell = null;
    private Vector3 previousCellPos;

    protected Animator animator;

    private float shootCooldown = 0f;

    protected string blowUpSound = "";
    //IA
    protected StateMachine<Character> stateMachine;

    public Action OnDeath;
    public Action<float> OnRangeChange;
    public Action<int, int> OnHealthChange;
    public Action<Vector3> OnPositionChange;
    public Action<int> OnMaxHealthChange;

    #region Public stats
    public float Range
    {
        get
        {
            return range;
        }
        protected set
        {
            range = value;
            OnRangeChange?.Invoke(value);
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        protected set
        {
            maxHealth = value;
            OnMaxHealthChange?.Invoke(value);
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        protected set
        {
            speed = value;
        }
    }

    public float RateOfFire
    {
        get
        {
            return rateOfFire;
        }
        protected set
        {
            rateOfFire = value;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
        protected set
        {
            damage = value;
        }
    }

    public float ProjectileSpeed
    {
        get
        {
            return projectileSpeed;
        }
        protected set
        {
            projectileSpeed = value;
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        protected set
        {
            OnHealthChange?.Invoke(currentHealth, value);
            currentHealth = value;
        }
    }
    #endregion

    #region Public upgrade stats
    public CharacterUpgrade RangeUpgrade
    {
        get
        {
            return rangeUpgrade;
        }
        protected set
        {
            rangeUpgrade = value;
        }
    }

    public CharacterUpgrade MaxHealthUpgrade
    {
        get
        {
            return maxHealthUpgrade;
        }
        protected set
        {
            maxHealthUpgrade = value;
        }
    }

    public CharacterUpgrade SpeedUpgrade
    {
        get
        {
            return speedUpgrade;
        }
        protected set
        {
            speedUpgrade = value;
        }
    }

    public CharacterUpgrade RateOfFireUpgrade
    {
        get
        {
            return rateOfFireUpgrade;
        }
        protected set
        {
            rateOfFireUpgrade = value;
        }
    }

    public CharacterUpgrade DamageUpgrade
    {
        get
        {
            return damageUpgrade;
        }
        protected set
        {
            damageUpgrade = value;
        }
    }

    public CharacterUpgrade ProjectileSpeedUpgrade
    {
        get
        {
            return projectileSpeedUpgrade;
        }
        protected set
        {
            projectileSpeedUpgrade = value;
        }
    }
    #endregion

    public bool IsMoving
    {
        get { return isMoving; }
    }

    public void UpgradeStats(int what)
    {
        switch (what)
        {
            case S.DAMAGE:
                Damage = damageUpgrade.Upgrade((int)Damage);
            break;

            case S.SPEED:
                Speed = speedUpgrade.Upgrade((int)Speed);
            break;

            case S.HP:
                MaxHealth = maxHealthUpgrade.Upgrade((int)MaxHealth);
            break;

            case S.PROJECTILE_SPEED:
                ProjectileSpeed = projectileSpeedUpgrade.Upgrade((int)ProjectileSpeed);
            break;

            case S.RANGE:
                Range = rangeUpgrade.Upgrade((int)Range);
            break;
                
            case S.ROF:
                RateOfFire = rateOfFireUpgrade.Upgrade((int)RateOfFire);
            break;

            default:
                Debug.Log("Silently ignored " + what);
            break;
        }
    }

    public int UpgradeCostOfStat(int what)
    {
        switch (what)
        {
            case S.DAMAGE:
                return damageUpgrade.nextCost;

            case S.SPEED:
                return speedUpgrade.nextCost;

            case S.HP:
                return maxHealthUpgrade.nextCost;

            case S.PROJECTILE_SPEED:
                return projectileSpeedUpgrade.nextCost;

            case S.RANGE:
                return rangeUpgrade.nextCost;

            case S.ROF:
                return rateOfFireUpgrade.nextCost;

            default:
                Debug.Log("Silently ignored " + what);
            return 0;
        }
    }
    
    public Vector3 Position
    {
        get { return transform.position; }
        protected set
        {
            OnPositionChange?.Invoke(value);
            transform.position = value;
        }
    }

    public Sensor EnemySensor
    {
        get  { return sensor;  }
    }


    protected void Awake()
    {
        sensor = GetComponentInChildren<Sensor>();
        animator = GetComponentInChildren<Animator>();
        CurrentHealth = maxHealth;

        maxHealthUpgrade = new CharacterUpgrade();
        speedUpgrade = new CharacterUpgrade();
        rateOfFireUpgrade = new CharacterUpgrade();
        rangeUpgrade = new CharacterUpgrade();
        damageUpgrade = new CharacterUpgrade();
        projectileSpeedUpgrade = new CharacterUpgrade();
        player = gameObject.AddComponent<AudioSourcePlayer>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        UpdateCurrentGridPos();
        
        OnRangeChange += EnemySensor.SetRange;
        OnDeath += () => gameObject.SetActive(false);
        OnDeath += BlowUpOnDeath;
        OnDeath += () => GameManager.Instance.CurrentMoney += moneyGainedOnDeath;
        EnemySensor.SetRange(range);
    }

    protected void OnDestroy()
    {
        OnRangeChange -= EnemySensor.SetRange;
        OnDeath -= BlowUpOnDeath;
    }

    // Update is called once per frame
    protected void Update()
    {
        HandleMoving();
    }

    private void FixedUpdate()
    {
        if (shootCooldown > 0f)
        {
            shootCooldown -= Time.fixedDeltaTime;
        }
    }

    #region Combat

    #region Attack

    private void HandleShooting()
    {
        if (EnemySensor.SightedObjects.Count > 0)
        {
            if (shootCooldown <= 0f)
            {
                ShootAt(EnemySensor.SightedObjects[0].Position);
            }
        }
    }

    public bool TryShootAt(Vector3 worldPos)
    {
        if (shootCooldown <= 0f)
        {
            ShootAt(worldPos);
            return true;
        }

        return false;
    }
    private void ShootAt(Vector3 worldPos)
    {
        RotateToward(worldPos);
        
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, MapManager.Instance.BulletParent)
            .GetComponent<Bullet>();
        
        

        Vector3 direction = (worldPos - transform.position).normalized;
        bullet.Direction = direction;
        bullet.Source = this;
        bullet.SetVelocityAndDamage(projectileSpeed, damage);
        
        bullet.gameObject.SetActive(true);
        
        shootCooldown = 1f / rateOfFire;

        player.PlaySound("son_tir");
    }
    
    #endregion
    
    #region Defense

    public virtual void TakeDamage(Character source, int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            if (OnDeath != null) OnDeath();
        }
    }
    
    protected virtual void BlowUpOnDeath()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        AudioManager.Instance.Player.PlaySound(blowUpSound);
    }

    #endregion
    #endregion

    #region Movements

    public void MoveTo(Vector3 worldPos)
    {

        if (currentPath != null && currentPath.Goal.CenterWorld == MapManager.Instance.LevelMap.GetTileAt(worldPos).CenterWorld)
        {
            return;
        }
        
        //stop previous movement
        StopMovement();
        
        //get path to new destination
        currentPath = MapManager.Instance.GetPathFromTo(transform.position, worldPos);
        
        //If there's no path, cancel movement.
        if (currentPath.IsEmpty)
        {
            currentPath = null;
        }
        else
        {
            isMoving = true;
        }
    }

    protected void HandleMoving()
    {

        if (currentPath == null)
        {
            return; //no movement
        }

        //Move toward the next cell if not reached
        if (targetCell != null && Vector3.Distance(transform.position, targetCell.CenterWorld) > 0.001f)
        {
            isMoving = true;
            MoveToward(targetCell.CenterWorld);

            Vector3 dir = (targetCell.CenterWorld - previousCellPos).normalized;
            RotateToward(transform.position + dir);
        }
        //Select the next cell to go if there's still some path to go
        else if (currentPath.HasNext())
        {
            previousCellPos = transform.position;
            targetCell = currentPath.Next();
        }
        //Stop the movement if it's over
        else
        {
            //The path is finished, we stop moving.
            StopMovement();
        }
    }

    protected virtual void MoveToward(Vector3 pos)
    {
        Vector3 remainingDistance = (pos - transform.position);
        Vector3 direction = remainingDistance.normalized;
        
        //Movement is capped with the remaining distance
        Vector3 deltaMovement = speed * Time.deltaTime * direction;

        Position += (deltaMovement.magnitude < remainingDistance.magnitude) ? deltaMovement : remainingDistance;

        UpdateCurrentGridPos(); //expensive?
        
    }

    protected virtual void RotateToward(Vector3 pos)
    {
        Vector3 remainingDistance = (pos - transform.position);
        Vector3 direction = remainingDistance.normalized;

        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        angle += offset;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, RotateSpeed * Time.deltaTime);
    }

    public virtual void StopMovement()
    {
        targetCell = null;
        currentPath = null;
        isMoving = false;
        
    }

    private void UpdateCurrentGridPos()
    {
        currentGridPos = MapManager.Instance.LevelMap.GetTileIndexAt(transform.position);
    }

    #endregion


    private void OnDrawGizmos()
    {
        if (currentPath != null)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < currentPath.Size - 1; i++)
            {
                Gizmos.DrawLine(currentPath[i].CenterWorld, currentPath[i+1].CenterWorld);
            }
        }

        if (IsMoving)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(MapManager.Instance.LevelMap[currentGridPos].CenterWorld, 0.25f);
        }

        if (stateMachine != null)
        {
            Gizmos.color = stateMachine.CurrentState.stateColor;
            Gizmos.DrawSphere(Position, 0.25f);
        }
    }
}
