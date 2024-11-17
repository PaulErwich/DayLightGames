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

    public Sprite[] bowUpgradeIcons;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        textBoxes = GetComponentsInChildren<TextMeshProUGUI>();
        images = GetComponentsInChildren<Image>();

        // 1 is to ignore Default
        EvolveTypeBow type = (EvolveTypeBow)UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(EvolveTypeBow)).Length);
        element = UpgradeDictionaries.bowUpgradeDictionary[type];

        element.icon = bowUpgradeIcons[((int)element.type) - 1];
        images[1].sprite = element.icon;

        textBoxes[0].text = element.type + " upgrade";
        textBoxes[1].text = element.description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public struct upgradeElement
{
    public upgradeElement(EvolveTypeBow _type, Color _color, string _desc)
    {
        type = _type;
        color = _color;
        description = _desc;
        icon = null;
    }
    public EvolveTypeBow type;
    public Color color;
    public string description;
    public Sprite icon;
}
