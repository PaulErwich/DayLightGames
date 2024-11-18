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

    // Sword upgrade dictionary
    public static Dictionary<EvolveTypeSword, upgradeElementSword> swordUpgradeDictionary = new Dictionary<EvolveTypeSword, upgradeElementSword>()
    {
        { EvolveTypeSword.Gauntlets, new upgradeElementSword(EvolveTypeSword.Gauntlets, new Color(0, 226, 226), "Gauntlets weapon upgrade") },
        { EvolveTypeSword.Shield, new upgradeElementSword(EvolveTypeSword.Shield, new Color(206, 32, 41), "Shield weapon upgrade") },
        { EvolveTypeSword.Dagger, new upgradeElementSword(EvolveTypeSword.Dagger, new Color(205, 205, 0), "Dagger weapon upgrade") },
        { EvolveTypeSword.Spear, new upgradeElementSword(EvolveTypeSword.Spear, new Color(0, 225, 0), "Spear weapon upgrade") },
        { EvolveTypeSword.Axe, new upgradeElementSword(EvolveTypeSword.Axe, new Color(110, 110, 110), "Axe weapon upgrade") },
        { EvolveTypeSword.GreatSword, new upgradeElementSword(EvolveTypeSword.GreatSword, new Color(0, 0, 0), "Great Sword weapon upgrade") },
    };

    public static Dictionary<ExtraUpgradeType, upgradeElementExtra> extraUpgradeDictionary = new Dictionary<ExtraUpgradeType, upgradeElementExtra>()
    {
        { ExtraUpgradeType.specialOne, new upgradeElementExtra(ExtraUpgradeType.specialOne, new Color(0, 226, 226), "Special upgrade one") },
        { ExtraUpgradeType.specialTwo, new upgradeElementExtra(ExtraUpgradeType.specialTwo, new Color(0, 226, 226), "Special upgrade one") },
        { ExtraUpgradeType.enhance, new upgradeElementExtra(ExtraUpgradeType.enhance, new Color(0, 226, 226), "Special upgrade one") },
        { ExtraUpgradeType.damage, new upgradeElementExtra(ExtraUpgradeType.damage, new Color(0, 226, 226), "Increase weapon damage") },
        { ExtraUpgradeType.attackSpeed, new upgradeElementExtra(ExtraUpgradeType.attackSpeed, new Color(0, 226, 226), "Increase weapon attack speed") },
    };

    public static Dictionary<EvolveTypeBow, upgradeStrings> bowExtraUgradeTitleDictionary = new Dictionary<EvolveTypeBow, upgradeStrings>()
    {
        { EvolveTypeBow.Ice, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeBow.Fire, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeBow.Electric, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeBow.Explosive, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeBow.Multishot, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeBow.Crossbow, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
    };

    public static Dictionary<EvolveTypeBow, upgradeStrings> bowExtraUgradeDescDictionary = new Dictionary<EvolveTypeBow, upgradeStrings>()
    {
        { EvolveTypeBow.Ice, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeBow.Fire, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeBow.Electric, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeBow.Explosive, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeBow.Multishot, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeBow.Crossbow, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
    };

    public static Dictionary<EvolveTypeSword, upgradeStrings> swordExtraUgradeTitleDictionary = new Dictionary<EvolveTypeSword, upgradeStrings>()
    {
        { EvolveTypeSword.Gauntlets, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeSword.Shield, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeSword.Dagger, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeSword.Spear, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeSword.Axe, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
        { EvolveTypeSword.GreatSword, new upgradeStrings("Special One Title", "Special Two Title", "Enhance Title", "Damange Title", "Attack Speed Title") },
    };

    public static Dictionary<EvolveTypeSword, upgradeStrings> swordExtraUgradeDescDictionary = new Dictionary<EvolveTypeSword, upgradeStrings>()
    {
        { EvolveTypeSword.Gauntlets, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeSword.Shield, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeSword.Dagger, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeSword.Spear, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeSword.Axe, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
        { EvolveTypeSword.GreatSword, new upgradeStrings("Special One Description", "Special Two Description", "Enhance Desc", "Damage desc", "Attack speed desc") },
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

