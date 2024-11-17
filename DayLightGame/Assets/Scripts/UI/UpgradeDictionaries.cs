using UnityEngine;
using System.Collections.Generic;

public class UpgradeDictionaries
{ 
    // Paul

    // Bow upgrade dictionary
    public static Dictionary<EvolveType, upgradeElement> bowUpgradeDictionary = new Dictionary<EvolveType, upgradeElement>()
    {
        { EvolveType.Ice, new upgradeElement(EvolveType.Ice, new Color(0, 227, 227), "Ice weapon upgrade") },   // Ice Blue
        { EvolveType.Fire, new upgradeElement(EvolveType.Fire, new Color(206, 32, 41), "Fire weapon upgrade") },  // Red
        { EvolveType.Electric, new upgradeElement(EvolveType.Electric, new Color(205, 205, 0), "Electric weapon upgrade") },    // Yellow
        { EvolveType.Explosive, new upgradeElement(EvolveType.Explosive, new Color(0, 255, 0), "Explosive weapon upgrade") },   // Green
        { EvolveType.Multishot, new upgradeElement(EvolveType.Multishot, new Color(110, 110, 110), "Multishot weapon upgrade") },   // Grey
        { EvolveType.Crossbow, new upgradeElement(EvolveType.Crossbow, new Color(0, 0, 0), "Crossbow weapon upgrade") },    // Black
    };

    public static Dictionary<statUpgradeType, Dictionary<shopUpgradeTier, int>> upgradeDictionary = new Dictionary<statUpgradeType, Dictionary<shopUpgradeTier, int>>()
    {
        { statUpgradeType.MaxHealth, new Dictionary<shopUpgradeTier, int>()
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
}

