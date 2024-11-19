using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;

    private EnemySpawner enemySpawner;

    public GameObject enemy;
    public GameObject elite;
    public GameObject boss;

    public GameObject shopUI;
    public GameObject upgradeUI;

    private int currentRoom = 3;
    private float scalingFactor = 1.25f;
    private int spawnCount = 1;
    private int additionalSpawningWaves = 2;
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

    public void NextRoom()
    {
        Player.instance.transform.position = new Vector2(1, -12);
        StartRoom();
    }

    // Scale the amount of enemies and additional waves with the current room number
    private void StartRoom()
    {
        enemiesThisRoom = Mathf.RoundToInt(spawnCount * Mathf.Pow(scalingFactor, currentRoom - 1));
        int spawningWavesThisRoom = Mathf.RoundToInt(additionalSpawningWaves * Mathf.Pow(scalingFactor, currentRoom - 1));

        enemySpawner.StartSpawning(enemiesThisRoom, spawningWavesThisRoom, currentRoom);
    }

    private void Update()
    {
        if (enemiesDestroyed >= enemiesThisRoom)
        {
            RoomEnd();
            enemiesDestroyed = 0;
        }
    }

    // If the room needs a shop or elite rewards
    public void RoomEnd()
    {
        if (Player.instance.meleeKillCount >= Player.instance.requiredKillsMelee)
        {
            upgradeUI.SetActive(true);
            upgradeUI.GetComponentInChildren<UpgradeShopManager>().SetupUpgradeShop(weaponType.melee, upgradeType.evolve);
            Player.instance.meleeKillCount -= Player.instance.requiredKillsMelee;
            Player.instance.requiredKillsMelee *= 2;
            return;
        }
        else if (Player.instance.rangedKillCount >= Player.instance.requiredKillsRanged)
        {
            upgradeUI.SetActive(true);
            upgradeUI.GetComponentInChildren<UpgradeShopManager>().SetupUpgradeShop(weaponType.ranged, upgradeType.evolve);
            Player.instance.rangedKillCount -= Player.instance.requiredKillsRanged;
            Player.instance.requiredKillsRanged *= 2;
            return;
        }
        upgradeUI.SetActive(false);

        switch (currentRoom)
        {
            default:
                // Standard Wave
                // No Shop
                NextRoom();
                break;
            case 3: case 6: case 9: case 12: case 15:
                // Standard Wave
                // Shop
                shopUI.SetActive(true);
                shopUI.GetComponentInChildren<RestoreHealthUI>().UpdateUI();
                break;
            case 5: case 11:
                NextRoom();
                // Elite Wave
                break;
            case 16:
                // Final Wave
                break;
        }
        currentRoom++;
    }

    public bool IsShopRoom()
    {
        switch (currentRoom)
        {
            default:
                return false;
            case 3: case 6: case 9: case 12: case 15:
                return true;
        }
    }
}
