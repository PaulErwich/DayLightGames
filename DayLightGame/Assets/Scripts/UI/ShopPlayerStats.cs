using UnityEngine;
using TMPro;


public class ShopPlayerStats : MonoBehaviour
{
    // Paul

    TextMeshProUGUI[] textBoxes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBoxes = GetComponentsInChildren<TextMeshProUGUI>();

        UpdateTextBoxes();
    }

    public void UpdateTextBoxes()
    {
        textBoxes[0].text = "GOLD: " + Player.instance.GetGold();
        textBoxes[1].text = "HEALTH: " + Player.instance.GetCurrentHealth() + " / " + Player.instance.GetMaxHealth();
    }
}
