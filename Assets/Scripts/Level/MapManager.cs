using System;
using System.Collections;
using System.Collections.Generic;
using Cawotte.Toolbox;
using Cawotte.Toolbox.Pathfinding;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Tilemaps;

public class MapManager : Singleton<MapManager>
{

    [SerializeField] private Grid grid;
    
    private Map levelMap;
    
    [SerializeField]
    private CentralBase centralBase;
    
    [SerializeField]
    private Pathfinder pathfinder;

    [SerializeField] private Spawner enemySpawner;
    
    [SerializeField] private Tilemap[] obstaclesTilemaps;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private AlliedShip testCharacter;

    private Vector3 lastClickedPos;
    public Map LevelMap => levelMap;

    public Transform BulletParent
    {
        get { return bulletParent; }
    }

    public CentralBase CentralBase
    {
        get { return centralBase; }
    }

    public Spawner EnemySpawner => enemySpawner;

    private void Awake()
    {
        levelMap = new Map(grid, obstaclesTilemaps);
        pathfinder = new Pathfinder(levelMap, true);
        enemySpawner = GetComponent<Spawner>();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public TilePath GetPathFromTo(Vector3 start, Vector3 goal)
    {
        return pathfinder.GetPath(start, goal);
    }

    private void OnDrawGizmos()
    {
        if (LevelMap != null)
        {
            Gizmos.color = Color.green;;
            Gizmos.DrawLine(LevelMap.Bounds.min, LevelMap.Bounds.max);
            
            Gizmos.DrawSphere(lastClickedPos, 0.3f);
        }
    }
}
