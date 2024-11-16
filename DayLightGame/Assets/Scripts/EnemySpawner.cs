using System.Collections;
using System.Linq;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

//Max

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemy;
    private GameObject elite;
    private GameObject boss;

    Vector2[] spawnLocationsStart = { 
        new Vector2(-21, 11),  new Vector2(-13, 11), new Vector2(7, 11), new Vector2(23, 11), new Vector2(13, -1), 
        new Vector2(-15, 1), new Vector2(-21, -11), new Vector2(-15, -11), new Vector2(13, -9), new Vector2(21, -9) 
    };

    Vector2[] spawnLoactionsDuring = {
        new Vector2(-21, 11), new Vector2(23, 11),
        new Vector2(-21, -11), new Vector2(21, -9)
    };

    private void Awake()
    {
        enemy = RoomManager.instance.enemy;
        elite = RoomManager.instance.elite;
        boss = RoomManager.instance.boss;

        elite.GetComponent<Enemy>().SetUpEnemy(30, 5, 3, 3);

        boss.GetComponent<Enemy>().SetUpEnemy(50, 5, 5, 10);
    }

    public void StartSpawning(int totalSpawnCount, int additionalSpawningWaves, bool spawnElite, bool spawnBoss)
    {
        if (spawnElite)
        {
            SpawnElite(spawnLoactionsDuring);
            totalSpawnCount--;
        }
        else if (spawnBoss)
        {
            SpawnBoss(spawnLoactionsDuring);
            totalSpawnCount--;
        }

        int spawnStart = totalSpawnCount / (int)(additionalSpawningWaves / 1.5f);
        int delayedSpawnCount = totalSpawnCount - spawnStart;
        int remainder = delayedSpawnCount % additionalSpawningWaves;
        spawnStart += remainder;
        delayedSpawnCount -= remainder;

        SpawnEnemies(spawnStart, spawnLocationsStart);

        delayedSpawnCount /= additionalSpawningWaves;

        StartCoroutine(Delay(additionalSpawningWaves, delayedSpawnCount));
    }

    private void SpawnEnemies(int spawnCount, Vector2[] spawnLocations)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 location = GetLocation(spawnLocations);
            Instantiate<GameObject>(enemy, new Vector3(location.x, location.y, 0f), Quaternion.identity);
        }
    }

    private void SpawnElite(Vector2[] spawnLocations)
    {
        Vector2 location = GetLocation(spawnLocations);
        Instantiate<GameObject>(elite, new Vector3(location.x, location.y, 0f), Quaternion.identity);
    }

    private void SpawnBoss(Vector2[] spawnLocations)
    {
        Vector2 location = GetLocation(spawnLocations);
        Instantiate<GameObject>(boss, new Vector3(location.x, location.y, 0f), Quaternion.identity);
    }

    private Vector2 GetLocation(Vector2[] spawnLocations)
    {
        int index = Random.Range(0, spawnLocations.Length);
        float randomX = Random.Range(-1.5f, 1.5f);
        float randomY = Random.Range(-1.5f, 1.5f);

        float spawnX = spawnLocations[index].x + randomX;
        float spawnY = spawnLocations[index].y + randomY;

        return new Vector2(spawnX, spawnY);
    }

    private IEnumerator Delay(int additionalSpawningWaves, int delayedSpawnCount)
    {
        for (int i = 0; i < additionalSpawningWaves; i++)
        {
            yield return StartCoroutine(DelayedSpawning(delayedSpawnCount));
        }
    }

    private IEnumerator DelayedSpawning(int delayedSpawnCount)
    {
        yield return new WaitForSeconds(3);
        SpawnEnemies(delayedSpawnCount, spawnLoactionsDuring);
    }
}
