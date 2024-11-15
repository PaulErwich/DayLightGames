using System.Collections;
using System.Linq;
using UnityEngine;

//Max

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    Vector2[] spawnLocationsStart = { 
        new Vector2(-21, 11),  new Vector2(-13, 11), new Vector2(7, 11), new Vector2(23, 11), new Vector2(13, -1), 
        new Vector2(-15, 1), new Vector2(-21, -11), new Vector2(-15, -11), new Vector2(13, -9), new Vector2(21, -9) 
    };

    Vector2[] spawnLoactionsDuring = {
        new Vector2(-21, 11), new Vector2(23, 11),
        new Vector2(-21, -11), new Vector2(21, -9)
    };

    private int totalSpawnCount = 40;
    private int remainingSpawnCount = 0;
    private int additionalSpawningWaves = 4;
    private int wave = 1;
    private float scalingFactor = 1.25f;

    private void Start()
    {
        int spawnStart = Mathf.RoundToInt(totalSpawnCount / (additionalSpawningWaves / 2));
        remainingSpawnCount = totalSpawnCount - spawnStart;

        SpawnEnemies(spawnStart, spawnLocationsStart);

        remainingSpawnCount /= additionalSpawningWaves;

        StartCoroutine(Delay());
    }

    private void SpawnEnemies(int spawnCount, Vector2[] spawnLocations)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            int index = Random.Range(0, spawnLocations.Length);
            float randomX = Random.Range(-1.5f, 1.5f);
            float randomY = Random.Range(-1.5f, 1.5f);
            
            float spawnX = spawnLocations[index].x + randomX;
            float spawnY = spawnLocations[index].y + randomY;

            Instantiate<GameObject>(enemy, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
        }
    }

    private IEnumerator Delay()
    {
        for (int i = 0; i < additionalSpawningWaves; i++)
        {
            yield return StartCoroutine(DelayedSpawning());
        }
    }

    private IEnumerator DelayedSpawning()
    {
        yield return new WaitForSeconds(3);
        SpawnEnemies(remainingSpawnCount, spawnLoactionsDuring);
    }
}
