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

    private Button button;
    private Color available = new Color(0, 255, 0, 200);
    private Color unavailable = new Color(255, 0, 0, 200);
    Image[] images;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();

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

       images  = GetComponentsInChildren<Image>();

        if (Player.instance.GetGold() >= element.goldCost)
        {
            images[0].color = available;
            button.interactable = true;
        }
        else
        {
            images[0].color = unavailable;
            button.interactable = false;
        }


        images[1].sprite = icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradePlayer()
    {
        if (Player.instance.TakeGold(element.goldCost))
        {
            button.interactable = false;
            images[0].color = unavailable;
            Player.instance.StatUpgrade(element.type, UpgradeDictionaries.upgradeDictionary[element.type][element.tier]);
        }
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
    MaxHealth,
    AttackSpeed,
    Speed,
    Armour,
}

