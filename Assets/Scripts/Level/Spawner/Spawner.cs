using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;

[Serializable]
public class Spawner : MonoBehaviour
{

    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Transform enemyParent;
    
    
    [SerializeField] private GameObject blueFlyPrefab;
    [SerializeField] private GameObject redFlyPrefab;
    [SerializeField] private GameObject whiteFighterPrefab;
    [SerializeField] private GameObject redFighterPrefab;
    [SerializeField] private GameObject greenClampPrefab;
    [SerializeField] private GameObject purpleClampPrefab;

    [SerializeField]
    private float maxSpawnSpeed = 0.1f;
    private float timerSpawnSpeed = 0f;
    
    [SerializeField] [ReadOnly] private Wave currentWave = null;

    public Action<Wave> OnWaveStart;
    public Action<Wave> OnSpawnEnd;
    public Action<Wave> OnWaveEnd;
    
    public Wave CurrentWave => currentWave;


    private void Awake()
    {
        currentWave = null;
        //GenerateAndStartWave(1);
    }

    // Update is called once per frame
    public void Update()
    {
        if (CurrentWave != null)
        {
            CurrentWave.UpdateWave(); //call it once per frame

            timerSpawnSpeed -= Time.deltaTime;
            
            //Max one new enemy per frame
            if (CurrentWave.ToInstantiate.Count > 0 && timerSpawnSpeed <= 0f)
            {
                //Instantiate the queued enemies
                SpawnEnemy(CurrentWave.ToInstantiate.Dequeue(), GetRandomSpawnPoints(1)[0]);
                GameManager.Instance.EnemyCount++;
                timerSpawnSpeed = maxSpawnSpeed;
            }

            if (IsWaveOver())
            {
                OnWaveEnd?.Invoke(currentWave);
                currentWave = null;
            }
        }
    }

    public void GenerateAndStartWave(int numWave)
    {
        currentWave = GenerateWave(numWave);
        
        currentWave.OnSpawnEnd = OnSpawnEnd;
        currentWave.StartWave();
        OnWaveStart?.Invoke(currentWave);
        
    }

    public bool IsWaveOver()
    {
        return (GameManager.Instance.EnemyCount == 0
                && CurrentWave.IsEnemySpawnOver()
            );
    }

    public void StopWave()
    {
        currentWave = null;
    }
    
    public Wave GenerateWave(int waveNumber)
    {

        //Compute Wave Parameters depending on Wave Number
        int spawnCount = Mathf.Min(4, 
                                1 + (int)Mathf.Floor(waveNumber * 0.5f));

        int blueFlyCount = (waveNumber + 1);
        int redFlyCount = Mathf.FloorToInt(((waveNumber + 1) / 3) * 2);
        int whiteFighterCount = Mathf.FloorToInt((waveNumber + 1) / 2);
        int redFighterCount = Mathf.FloorToInt((waveNumber + 1) / 4);
        int greenClampCount = Mathf.FloorToInt(waveNumber * 0.8f);
        int purpleClampCount = Mathf.FloorToInt(waveNumber * 0.4f);

        float spawnLenght = 5f + waveNumber * 5f;
        
        //Generate a wave with them
        List<Vector3> spawnPositionForWave = GetRandomSpawnPoints(spawnCount);
        
        Dictionary<GameObject, int> enemies = new Dictionary<GameObject, int>();
        
        enemies.Add(blueFlyPrefab, redFlyCount);
        enemies.Add(redFlyPrefab, blueFlyCount);
        enemies.Add(whiteFighterPrefab, whiteFighterCount);
        enemies.Add(redFighterPrefab, redFighterCount);
        enemies.Add(greenClampPrefab, greenClampCount);
        enemies.Add(purpleClampPrefab, purpleClampCount);

        Wave wave = new Wave(
            waveNumber,
            spawnLenght,
            enemies,
            spawnPositionForWave);

        return wave;
    }

    private void SpawnEnemy(GameObject prefab, Vector3 spawnPos)
    {
        GameObject enemy = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity, enemyParent);
        
        enemy.gameObject.SetActive(true);
    }
    

    private List<Vector3> GetSpawnPoints()
    {
        List<Vector3> spawnPos = new List<Vector3>();
        foreach (Transform tf in spawnPoints)
        {
            if (MapManager.Instance.LevelMap.IsInBounds(tf.position))
            {
                spawnPos.Add(MapManager.Instance.LevelMap.GetTileAt(tf.position).CenterWorld);
            }
        }

        return spawnPos;
    }

    private List<Vector3> GetRandomSpawnPoints(int numOfSpawn)
    {
        List<Vector3> randomPoints = GetSpawnPoints();
        randomPoints = randomPoints.OrderBy( x => UnityEngine.Random.value ).ToList();
        
        //Cut the number of points to fit numSpawn
        while (numOfSpawn < randomPoints.Count)
        {
            randomPoints.Remove(randomPoints.Last());
        }

        return randomPoints;

    }
}
