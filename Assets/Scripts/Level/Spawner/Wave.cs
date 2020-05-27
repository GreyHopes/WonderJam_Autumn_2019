using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Wave
{

    [SerializeField] private int numWave;
    
    
    [SerializeField]
    private float spawnLength;

    
    [SerializeField] private List<Vector3> spawnPos;

    private Dictionary<GameObject, int> enemies;
    
    private Dictionary<GameObject, int> instantiated;

    //To avoid too many instantiate at the same time
    private Queue<GameObject> toInstantiate;

    [SerializeField][ReadOnly]
    private float timeSinceStart = 0f;

    public Action<Wave> OnSpawnEnd;

    public Wave(int numWave, float spawnLength, Dictionary<GameObject, int> enemies, List<Vector3> spawnPos)
    {
        this.spawnLength = spawnLength;
        this.enemies = enemies;
        this.spawnPos = spawnPos;

        toInstantiate = new Queue<GameObject>();
        instantiated = new Dictionary<GameObject, int>();
        
    }

    public Queue<GameObject> ToInstantiate => toInstantiate;

    public int NumWave => numWave;

    public void StartWave()
    {
        timeSinceStart = 0f;
        foreach (GameObject enemy in enemies.Keys)
        {
            instantiated.Add(enemy, 0); //0 enemies spawned yet
        }
        
        //Shuffle the spawn pos
        spawnPos = spawnPos.OrderBy( x => UnityEngine.Random.value ).ToList();

    }

    public bool IsEnemySpawnOver()
    {
        return timeSinceStart >= spawnLength && toInstantiate.Count == 0;
    }

    /// <summary>
    /// Call only once per frame!
    /// </summary>
    public void UpdateWave()
    {
        timeSinceStart += Time.deltaTime;

        foreach (GameObject enemy in enemies.Keys)
        {
            int newEnemies = GetNumberOfNewEnemiesToInstantiate(enemy);

            for (int i = 0; i < newEnemies; i++)
            {
                ToInstantiate.Enqueue(enemy);
                instantiated[enemy]++; //this one is counted as one that will spawn
            }
        }

        if (timeSinceStart > spawnLength)
        {
            OnSpawnEnd?.Invoke(this);
            OnSpawnEnd = null;
        }
    }

    public Vector3 GetCurrentSpawnPos()
    {
        float time = (timeSinceStart >= spawnLength) ? spawnLength : timeSinceStart;
        
        float num = Mathf.Lerp(0, spawnPos.Count, time / spawnLength);

        int roundedNumber = (int) Mathf.Floor(num);
        if (roundedNumber == spawnPos.Count)
        {
            return spawnPos.Last();
        }
        else
        {
            return spawnPos[roundedNumber];
        }
    }

    public int GetNumberOfRemainingEnemies()
    {
        int remainingEnnemiesToSpawn = 0;
        foreach (GameObject enemy in enemies.Keys)
        {
            remainingEnnemiesToSpawn += enemies[enemy] - instantiated[enemy];
        }

        return remainingEnnemiesToSpawn;
        
    }
    private int GetNumberOfNewEnemiesToInstantiate(GameObject enemy)
    {
        return GetNumberOfEnemiesToInstantiate(enemy) - instantiated[enemy];
    }

    //ugly function that spread them evenly
    private int GetNumberOfEnemiesToInstantiate(GameObject enemy)
    {
        if (timeSinceStart >= spawnLength)
        {
            return enemies[enemy];
        }
        
        float num = Mathf.Lerp(0, enemies[enemy], timeSinceStart / spawnLength);

        return (int) Mathf.Floor(num);
    }
    
    
}
