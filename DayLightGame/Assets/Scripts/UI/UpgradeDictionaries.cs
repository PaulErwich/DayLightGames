using UnityEngine;
using System.Collections.Generic;

public class UpgradeDictionaries
{ 
    // Paul

    // Bow upgrade dictionary
    public static Dictionary<EvolveTypeBow, upgradeElementBow> bowUpgradeDictionary = new Dictionary<EvolveTypeBow, upgradeElementBow>()
    {
        { EvolveTypeBow.Ice, new upgradeElementBow(EvolveTypeBow.Ice, new Color(0, 226, 226), "Ice weapon upgrade") },
        { EvolveTypeBow.Fire, new upgradeElementBow(EvolveTypeBow.Fire, new Color(206, 32, 41), "Fire weapon upgrade") },
        { EvolveTypeBow.Electric, new upgradeElementBow(EvolveTypeBow.Electric, new Color(205, 205, 0), "Electric weapon upgrade") },
        { EvolveTypeBow.Explosive, new upgradeElementBow(EvolveTypeBow.Explosive, new Color(0, 225, 0), "Explosive weapon upgrade") },
        { EvolveTypeBow.Multishot, new upgradeElementBow(EvolveTypeBow.Multishot, new Color(110, 110, 110), "Multishot weapon upgrade") },
        { EvolveTypeBow.Crossbow, new upgradeElementBow(EvolveTypeBow.Crossbow, new Color(0, 0, 0), "Crossbow weapon upgrade") },
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

