using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SetupWeaponUpgrade : MonoBehaviour
{
    // Paul

    public upgradeElement element;
    private Button button;
    private TextMeshProUGUI[] textBoxes;
    private Image[] images;

    public static List<int> currentUpgradeOptions = new List<int>();

    int GenerateUpgradeType(int min, int max)
    {
        // 1 is to ignore the default
        int type = UnityEngine.Random.Range(min, max);
        if (currentUpgradeOptions.Contains(type))
        {
            // Regenerate type until it's a new one
            while (currentUpgradeOptions.Contains(type))
                type = UnityEngine.Random.Range(min, max);
            currentUpgradeOptions.Add(type);
        }
        else
            currentUpgradeOptions.Add(type);

        return type;
    }

    public void SetupUpgradeIcon(weaponType _wepeonType, upgradeType _upgradeType)
    {
        button = GetComponent<Button>();
        textBoxes = GetComponentsInChildren<TextMeshProUGUI>();
        images = GetComponentsInChildren<Image>();

        switch (_wepeonType)
        {
            case weaponType.melee:
                switch (_upgradeType)
                {
                    case upgradeType.evolve:
                        {
                            int type = GenerateUpgradeType(1, System.Enum.GetValues(typeof(EvolveTypeSword)).Length);
                            element = UpgradeDictionaries.swordUpgradeDictionary[(EvolveTypeSword)type];
                            element.icon = UISpriteDictionary.instance.swordUpgradeIcons[type - 1];
                            break;
                        }
                    case upgradeType.addon:
                        {
                            int type = GenerateUpgradeType(0, System.Enum.GetValues(typeof(ExtraUpgradeType)).Length);
                            element = UpgradeDictionaries.extraUpgradeDictionary[(ExtraUpgradeType)type];
                            element.icon = UISpriteDictionary.instance.specialUpgradeIcons[type];

                            EvolveTypeSword tempType = (EvolveTypeSword)UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(EvolveTypeSword)).Length);
                            element.title = UpgradeDictionaries.swordExtraUgradeTitleDictionary[tempType].strings[type];
                            element.description = UpgradeDictionaries.swordExtraUgradeDescDictionary[tempType].strings[type];
                            break;
                        }
                }
                break;
            case weaponType.ranged:
                switch(_upgradeType)
                {
                    case upgradeType.evolve:
                        {
                            int type = GenerateUpgradeType(1, System.Enum.GetValues(typeof(EvolveTypeBow)).Length);
                            element = UpgradeDictionaries.bowUpgradeDictionary[(EvolveTypeBow)type];
                            element.icon = UISpriteDictionary.instance.bowUpgradeIcons[type - 1];
                            break;
                        }
                    case upgradeType.addon:
                        {
                            int type = GenerateUpgradeType(0, System.Enum.GetValues(typeof(ExtraUpgradeType)).Length);
                            element = UpgradeDictionaries.extraUpgradeDictionary[(ExtraUpgradeType)type];
                            element.icon = UISpriteDictionary.instance.specialUpgradeIcons[type];

                            EvolveTypeBow tempType = (EvolveTypeBow)UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(EvolveTypeBow)).Length);
                            element.title = UpgradeDictionaries.bowExtraUgradeTitleDictionary[tempType].strings[type];
                            element.description = UpgradeDictionaries.bowExtraUgradeDescDictionary[tempType].strings[type];
                            break;
                        }
                }
                break;
        }

        images[0].color = element.color;
        images[1].sprite = element.icon;

        textBoxes[0].text = element.title + " upgrade";
        textBoxes[1].text = element.description;

        button.onClick.AddListener(RoomManager.instance.RoomEnd);
    }
}

[Serializable]
public class upgradeElement
{
    public upgradeElement(Color _color, string _desc, string _title)
    {
        color = _color;
        title = _title;
        description = _desc;
        icon = null;
    }
    public Color color;
    public string title;
    public string description;
    public Sprite icon;
}

public class upgradeElementBow : upgradeElement
{
    public upgradeElementBow(EvolveTypeBow _type, Color _color, string _desc) : base(_color, _desc, _type.ToString())
    {
        type = _type;
    }
    public EvolveTypeBow type;
}

public class upgradeElementSword : upgradeElement
{
    public upgradeElementSword(EvolveTypeSword _type, Color _color, string _desc) : base(_color, _desc, _type.ToString())
    {
        if (type == EvolveTypeSword.GreatSword)
        {
            title = "Great Sword";
        }
        type = _type;
    }
    EvolveTypeSword type;
}

public class upgradeElementExtra : upgradeElement
{
    public upgradeElementExtra(ExtraUpgradeType _type, Color _color, string _desc) : base(_color, _desc, _type.ToString())
    {
        type = _type;
    }
    ExtraUpgradeType type;
}

public class upgradeStrings
{
    public upgradeStrings(string _specialOneString, string _specialTwoString, string _enhanceString, string _damageString, string _attackSpeedString)
    {
        strings = new List<string> { _specialOneString, _specialTwoString, _enhanceString, _damageString, _attackSpeedString};
    }

    public List<string> strings;
}

public enum weaponType
{
    melee,
    ranged
}

public enum upgradeType
{
    evolve,
    addon
}

public enum ExtraUpgradeType
{
    specialOne,
    specialTwo,
    enhance,
    damage,
    attackSpeed
}