using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetupShopElement : MonoBehaviour
{
    // Paul

    [SerializeField]
    public shopElement element;
    public Sprite icon;

    Dictionary<statUpgradeType, Dictionary<shopUpgradeTier, int>> upgradeDictionary = new Dictionary<statUpgradeType, Dictionary<shopUpgradeTier, int>>()
    {
        { statUpgradeType.Health, new Dictionary<shopUpgradeTier, int>()
            {
                {shopUpgradeTier.Common, 5 },
                {shopUpgradeTier.Uncommon, 10 },
                { shopUpgradeTier.Rare, 15},
            }
        },
        { statUpgradeType.AttackSpeed, new Dictionary<shopUpgradeTier, int>()
            {
                {shopUpgradeTier.Common, 1 },
                {shopUpgradeTier.Uncommon, 2 },
                { shopUpgradeTier.Rare, 3},
            }
        },
        { statUpgradeType.Speed, new Dictionary<shopUpgradeTier, int>()
            {
                {shopUpgradeTier.Common, 1 },
                {shopUpgradeTier.Uncommon, 2 },
                { shopUpgradeTier.Rare, 3},
            }
        },
        { statUpgradeType.Armour, new Dictionary<shopUpgradeTier, int>()
            {
                {shopUpgradeTier.Common, 1 },
                {shopUpgradeTier.Uncommon, 2 },
                { shopUpgradeTier.Rare, 2},
            }
        },
        };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (UnityEngine.Random.Range(0, 100))
        {
            case <= ((int)shopUpgradeTier.Common):
                element.tier = shopUpgradeTier.Common;
                break;
            case <= ((int)shopUpgradeTier.Common) + ((int)shopUpgradeTier.Uncommon):
                element.tier = shopUpgradeTier.Uncommon;
                break;
            case <= ((int)shopUpgradeTier.Common) + ((int)shopUpgradeTier.Uncommon) + ((int)shopUpgradeTier.Rare):
                element.tier = shopUpgradeTier.Rare;
                break;
        }

        //element.type = (shopUpgradeType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(shopUpgradeType)).Length);
        element.goldCost = UnityEngine.Random.Range(5, 10);
        
        TextMeshProUGUI[] textBoxes = GetComponentsInChildren<TextMeshProUGUI>();

        textBoxes[0].text = element.tier.ToString() + ": " + element.type.ToString();
        textBoxes[1].text = "Cost: " + element.goldCost.ToString() + " Gold";

        GetComponentsInChildren<Image>()[1].sprite = icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradePlayer()
    {
        // Upgrade player stat
        int value = upgradeDictionary[element.type][element.tier];
    }
}

[Serializable]
public struct shopElement
{
    public shopUpgradeTier tier;
    public statUpgradeType type;
    public int goldCost;
    public int statIncrease;
}

public enum shopUpgradeTier
{
    Rare = 10,
    Uncommon = 20,
    Common = 70,
}

public enum statUpgradeType
{
    Health,
    AttackSpeed,
    Speed,
    Armour,
}

