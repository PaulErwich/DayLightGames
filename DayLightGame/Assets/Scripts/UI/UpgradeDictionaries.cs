using UnityEngine;
using System.Collections.Generic;

public class UpgradeDictionaries
{ 
    // Paul

    // Bow upgrade dictionary
    public static Dictionary<EvolveTypeBow, upgradeElement> bowUpgradeDictionary = new Dictionary<EvolveTypeBow, upgradeElement>()
    {
        { EvolveTypeBow.Ice, new upgradeElement(EvolveTypeBow.Ice, new Color(0, 0, 255), "Ice weapon upgrade") },
        { EvolveTypeBow.Fire, new upgradeElement(EvolveTypeBow.Fire, new Color(255, 0, 0), "Fire weapon upgrade") },
        { EvolveTypeBow.Electric, new upgradeElement(EvolveTypeBow.Electric, new Color(255, 0, 0), "Electric weapon upgrade") },
        { EvolveTypeBow.Explosive, new upgradeElement(EvolveTypeBow.Explosive, new Color(255, 0, 0), "Explosive weapon upgrade") },
        { EvolveTypeBow.Multishot, new upgradeElement(EvolveTypeBow.Multishot, new Color(255, 0, 0), "Multishot weapon upgrade") },
        { EvolveTypeBow.Crossbow, new upgradeElement(EvolveTypeBow.Crossbow, new Color(255, 0, 0), "Crossbow weapon upgrade") },
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

