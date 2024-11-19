using UnityEngine;
using System.Collections.Generic;

public class UpgradeDictionaries
{ 
    // Paul

    // Bow upgrade dictionary
    public static Dictionary<EvolveTypeBow, upgradeElementBow> bowUpgradeDictionary = new Dictionary<EvolveTypeBow, upgradeElementBow>()
    {
        //Description
        { EvolveTypeBow.Ice, new upgradeElementBow(EvolveTypeBow.Ice, new Color(0, 226, 226), "Apply a Freeze to enemies") },
        { EvolveTypeBow.Fire, new upgradeElementBow(EvolveTypeBow.Fire, new Color(206, 32, 41), "Apply a Burn to enemies") },
        { EvolveTypeBow.Electric, new upgradeElementBow(EvolveTypeBow.Electric, new Color(205, 205, 0), "Apply a Slow to enemies") },
        { EvolveTypeBow.Explosive, new upgradeElementBow(EvolveTypeBow.Explosive, new Color(0, 225, 0), "Arrows explode on contact") },
        { EvolveTypeBow.Multishot, new upgradeElementBow(EvolveTypeBow.Multishot, new Color(110, 110, 110), "Shoot multiple arrows at once") },
        { EvolveTypeBow.Crossbow, new upgradeElementBow(EvolveTypeBow.Crossbow, new Color(0, 0, 0), "Arrows pierce through enemies") },
    };

    // Sword upgrade dictionary
    public static Dictionary<EvolveTypeSword, upgradeElementSword> swordUpgradeDictionary = new Dictionary<EvolveTypeSword, upgradeElementSword>()
    {
        //Description
        { EvolveTypeSword.Gauntlets, new upgradeElementSword(EvolveTypeSword.Gauntlets, new Color(0, 226, 226), "Punch enemies with alternating hits") },
        { EvolveTypeSword.Shield, new upgradeElementSword(EvolveTypeSword.Shield, new Color(206, 32, 41), "Slam enemies and block projectiles") },
        { EvolveTypeSword.Dagger, new upgradeElementSword(EvolveTypeSword.Dagger, new Color(205, 205, 0), "Short range slashes apply bleed to enemies") },
        { EvolveTypeSword.Spear, new upgradeElementSword(EvolveTypeSword.Spear, new Color(0, 225, 0), "Long range stabs apply bleed to enemies") },
        { EvolveTypeSword.Axe, new upgradeElementSword(EvolveTypeSword.Axe, new Color(110, 110, 110), "Decimate enemies with large slashes") },
        { EvolveTypeSword.GreatSword, new upgradeElementSword(EvolveTypeSword.GreatSword, new Color(0, 0, 0), "Strike enemies with great force") },
    };

    public static Dictionary<ExtraUpgradeType, upgradeElementExtra> extraUpgradeDictionary = new Dictionary<ExtraUpgradeType, upgradeElementExtra>()
    {
        //DO NOT
        { ExtraUpgradeType.specialOne, new upgradeElementExtra(ExtraUpgradeType.specialOne, new Color(0, 226, 226), "Special upgrade one") },
        { ExtraUpgradeType.specialTwo, new upgradeElementExtra(ExtraUpgradeType.specialTwo, new Color(0, 226, 226), "Special upgrade one") },
        { ExtraUpgradeType.enhance, new upgradeElementExtra(ExtraUpgradeType.enhance, new Color(0, 226, 226), "Special upgrade one") },
        { ExtraUpgradeType.damage, new upgradeElementExtra(ExtraUpgradeType.damage, new Color(0, 226, 226), "Increase weapon damage") },
        { ExtraUpgradeType.attackSpeed, new upgradeElementExtra(ExtraUpgradeType.attackSpeed, new Color(0, 226, 226), "Increase weapon attack speed") },
    };

    public static Dictionary<EvolveTypeBow, upgradeStrings> bowExtraUgradeTitleDictionary = new Dictionary<EvolveTypeBow, upgradeStrings>()
    {
        { EvolveTypeBow.Ice, new upgradeStrings("Flash freeze", "Frozen trail", "+Freeze duration", "+Damage", "+Attack Speed") },
        { EvolveTypeBow.Fire, new upgradeStrings("Fire blast", "Flaming trail", "+Burn duration", "+Damage", "+Attack Speed") },
        { EvolveTypeBow.Electric, new upgradeStrings("Electrical burst", "Lightning trail", "+Slow duration", "+Damage", "+Attack Speed") },
        { EvolveTypeBow.Explosive, new upgradeStrings("Cluster bombs", "Gravity bomb", "+Blast radius", "+Damage", "+Attack Speed") },
        { EvolveTypeBow.Multishot, new upgradeStrings("Splinter arrows", "Arrow dash", "+Arrow count", "+Damage", "+Attack Speed") },
        { EvolveTypeBow.Crossbow, new upgradeStrings("First strike", "Critical strike", "+Pierce", "+Damage", "+Attack Speed") },
    };

    public static Dictionary<EvolveTypeBow, upgradeStrings> bowExtraUgradeDescDictionary = new Dictionary<EvolveTypeBow, upgradeStrings>()
    {
        { EvolveTypeBow.Ice, new upgradeStrings("Freeze nearby enemies on hit", "Arrows leave a trail that Freeze enemies on contact", "Increases duration of Freeze", "Increases the damage of the arrow by +X", "Decreases recharge time of arrows") },
        { EvolveTypeBow.Fire, new upgradeStrings("Burn nearby enemies on hit", "Arrows leave a trail that Burns enemies on contact", "Increases duration of Burn", "Increases the damage of the arrow by +X", "Decreases recharge time of arrows") },
        { EvolveTypeBow.Electric, new upgradeStrings("Slow nearby enemies on hit", "Arrows leave a trail that slow enemies on contact", "Increases duration of Slow", "Increases the damage of the arrow by +X", "Decreases recharge time of arrows") },
        { EvolveTypeBow.Explosive, new upgradeStrings("Cluster bombs detonate on hit", "Pulls all nearby enemies in on hit", "Increases blast radius of arrows", "Increases the damage of the arrow by +X", "Decreases recharge time of arrows") },
        { EvolveTypeBow.Multishot, new upgradeStrings("Arrows split into three on hit", "Arrows are fired when you dash", "Increases amount of arrows fired", "Increases the damage of the arrow by +X", "Decreases recharge time of arrows") },
        { EvolveTypeBow.Crossbow, new upgradeStrings("Arrows deal +100% damage to the first enemy hit", "Arrows have a 25% chance to critically strike", "Increases the amount of enemies the arrow can pierce", "Increases the damage of the arrow by +X", "Decreases recharge time of arrows") },
    };

    public static Dictionary<EvolveTypeSword, upgradeStrings> swordExtraUgradeTitleDictionary = new Dictionary<EvolveTypeSword, upgradeStrings>()
    {
        { EvolveTypeSword.Gauntlets, new upgradeStrings("Double dash", "Thunder punches", "Dual slam", "+Damange", "+Attack Speed") },
        { EvolveTypeSword.Shield, new upgradeStrings("Thorns", "Ice impact", "Supersize", "+Damange", "+Attack Speed") },
        { EvolveTypeSword.Dagger, new upgradeStrings("Execution", "Stamina", "+Bleed duration", "+Damange", "+Attack Speed") },
        { EvolveTypeSword.Spear, new upgradeStrings("Trifold strike", "Extend", "+Bleed duration", "+Damange", "+Attack Speed") },
        { EvolveTypeSword.Axe, new upgradeStrings("Reckless swing", "Deadly dash", "Ranged decimation", "+Damange", "+Attack Speed") },
        { EvolveTypeSword.GreatSword, new upgradeStrings("Heavy blows", "Shredding slash", "Blades reach", "+Damange", "+Attack Speed") },
    };

    public static Dictionary<EvolveTypeSword, upgradeStrings> swordExtraUgradeDescDictionary = new Dictionary<EvolveTypeSword, upgradeStrings>()
    {
        { EvolveTypeSword.Gauntlets, new upgradeStrings("Dashes travel twice as far", "Applies a slow with every hit", "Every third hit uses both hands dealing bonus damage", "Increases the damage of every hit by X", "Increases attack speed by X") },
        { EvolveTypeSword.Shield, new upgradeStrings("Enemies that hit the shield take damage", "Freezes enemies on hit", "Increases size of shield", "Increases the damage of every hit by X", "Increases attack speed by X") },
        { EvolveTypeSword.Dagger, new upgradeStrings("Critically strike enemies below 50% health", "Dash cooldown is reduced by 50%", "Enemies bleed for twice as long", "Increases the damage of every hit by X", "Increases attack speed by X") },
        { EvolveTypeSword.Spear, new upgradeStrings("Rapidly attack three times in a cone", "Spear reach is increased", "Enemies bleed for twice as long", "Increases the damage of every hit by X", "Increases attack speed by X") },
        { EvolveTypeSword.Axe, new upgradeStrings("Axe swings in a full circle", "Axe swings when dashing", "Enemies further away take more damage", "Increases the damage of every hit by X", "Increases attack speed by X") },
        { EvolveTypeSword.GreatSword, new upgradeStrings("25% chance to critically strike", "Destroy projectiles on hit", "Great sword size is increased", "Increases the damage of every hit by X", "Increases attack speed by X") },
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

