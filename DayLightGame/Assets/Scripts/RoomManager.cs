using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    private EnemySpawner enemySpawner;

    public GameObject enemy;
    public GameObject elite;
    public GameObject boss;

    private int currentRoom = 5;
    private float scalingFactor = 1.25f;
    private int spawnCount = 15;
    private int additionalSpawningWaves = 4;
    private int enemiesThisRoom;

    public int enemiesDestroyed = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemySpawner = gameObject.AddComponent<EnemySpawner>();
        NextRoom();
    }

    private void NextRoom()
    {
        switch (currentRoom)
        {
            default:
                DefaultSpawning();
                break;
            case 5: case 11:
                EliteSpawning();
                break;
            case 16:
                BossSpawning();
                break;
        }
    }

    private void DefaultSpawning()
    {
        enemiesThisRoom = Mathf.RoundToInt(spawnCount * Mathf.Pow(scalingFactor, currentRoom - 1));
        int spawningWavesThisRoom = Mathf.RoundToInt(additionalSpawningWaves * Mathf.Pow(scalingFactor, currentRoom - 1));

        enemySpawner.StartSpawning(enemiesThisRoom, spawningWavesThisRoom, false, false);
    }

    private void EliteSpawning()
    {
        enemiesThisRoom = Mathf.RoundToInt(spawnCount * Mathf.Pow(scalingFactor, currentRoom - 1));
        int spawningWavesThisRoom = Mathf.RoundToInt(additionalSpawningWaves * Mathf.Pow(scalingFactor, currentRoom - 1));

        enemySpawner.StartSpawning(enemiesThisRoom, spawningWavesThisRoom, true, false);
    }

    private void BossSpawning()
    {
        enemiesThisRoom = Mathf.RoundToInt(spawnCount * Mathf.Pow(scalingFactor, currentRoom - 1));
        int spawningWavesThisRoom = Mathf.RoundToInt(additionalSpawningWaves * Mathf.Pow(scalingFactor, currentRoom - 1));

        enemySpawner.StartSpawning(enemiesThisRoom, spawningWavesThisRoom, false, true);
    }

    private void Update()
    {
        if (enemiesDestroyed >= enemiesThisRoom)
        {
            RoomEnd();
        }
    }

    public void RoomEnd()
    {
        switch (currentRoom)
        {
            default:
                // Standard Wave
                // No Shop
                break;
            case 3: case 6: case 9: case 12: case 15:
                // Standard Wave
                // Shop at end
                break;
            case 5: case 11:
                // Elite Wave
                break;
            case 16:
                // Final Wave
                break;
        }
        currentRoom++;
        enemiesDestroyed = 0;
    }
}
