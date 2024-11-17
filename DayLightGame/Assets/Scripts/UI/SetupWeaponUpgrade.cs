using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SetupWeaponUpgrade : MonoBehaviour
{
    // Paul

    public upgradeElementBow element;
    private Button button;
    private TextMeshProUGUI[] textBoxes;
    private Image[] images;

    public Sprite[] bowUpgradeIcons;

    static List<int> currentUpgradeOptions = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        textBoxes = GetComponentsInChildren<TextMeshProUGUI>();
        images = GetComponentsInChildren<Image>();

        element.icon = bowUpgradeIcons[((int)element.type) - 1];
        images[0].color = element.color;
        images[1].sprite = element.icon;

        textBoxes[0].text = element.type + " upgrade";
        textBoxes[1].text = element.description;
    }

    public void SetupUpgradeIcon(weaponType _wepeonType, upgradeType _upgradeType)
    {
        switch(_wepeonType)
        {
            case weaponType.melee:
                switch (_upgradeType)
                {
                    case upgradeType.evolve:

                        break;
                    case upgradeType.addon:
                        break;
                }
                break;
            case weaponType.ranged:
                switch(_upgradeType)
                {
                    case upgradeType.evolve:
                        // 1 is to ignore Default
                        int type = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(EvolveTypeBow)).Length);
                        if (currentUpgradeOptions.Contains(type))
                        {
                            // Regenerate type until it's a new one
                            while (currentUpgradeOptions.Contains(type))
                                type = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(EvolveTypeBow)).Length);
                            currentUpgradeOptions.Add(type);
                        }
                        else
                            currentUpgradeOptions.Add(type);

                        element = UpgradeDictionaries.bowUpgradeDictionary[(EvolveTypeBow)type];
                        break;
                    case upgradeType.addon:
                        break;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class upgradeElement
{
    public upgradeElement(Color _color, string _desc)
    {
        color = _color;
        description = _desc;
        icon = null;
    }
    public Color color;
    public string description;
    public Sprite icon;
}

public class upgradeElementBow : upgradeElement
{
    public upgradeElementBow(EvolveTypeBow _type, Color _color, string _desc) : base(_color, _desc)
    {
        type = _type;
    }
    public EvolveTypeBow type;
}

public class upgradeElementSword : upgradeElement
{
    public upgradeElementSword(EvolveTypeSword _type, Color _color, string _desc) : base(_color, _desc)
    {
        type = _type;
    }
    EvolveTypeSword type;
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

public enum extraUpgradeType
{
    specialOne,
    specialTwo,
    enhance,
    damage,
    attackSpeed
}