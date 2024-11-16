using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RestoreHealthUI : MonoBehaviour
{
    // Paul

    // Conversion ratio:
    // 1 Gold = 2 health
    private int maxHealthRestore = 10;
    private int currentHealthRestore = 10;
    private int maxGoldCost = 5;
    private int currentGoldCost = 5;
    private TextMeshProUGUI[] textBoxes;
    private Button button;
    public Image image;

    private Color available = new Color(0, 255, 0, 200);
    private Color unavailable = new Color(255, 0, 0, 200);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.instance.GiveGold(100);

        textBoxes = GetComponentsInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        UpdateUI();
    }

    public void RestorePlayerHealth()
    {
        if (Player.instance.TakeGold(currentGoldCost))
        {
            Player.instance.RestoreHealth(currentHealthRestore);

            if (Player.instance.GetMissingHealth() == 0)
                button.interactable = false;
        }
    }

    public void UpdateUI()
    {
        CalculateCost();

        textBoxes[0].text = "Restore " + currentHealthRestore + " health";
        textBoxes[1].text = currentGoldCost + " Gold";

        if (Player.instance.GetGold() > 0 && Player.instance.GetMissingHealth() > 0)
            image.color = available;
        else
        {
            image.color = unavailable;
            button.interactable = false;
        }
    }

    void CalculateCost()
    {
        int playerMissingHealth = Player.instance.GetMissingHealth();
        if (playerMissingHealth > maxHealthRestore)
        {
            currentHealthRestore = maxHealthRestore;
            currentGoldCost = maxGoldCost;
        }
        else
        {
            currentHealthRestore = playerMissingHealth;
            currentGoldCost = (int)Mathf.Ceil((float)playerMissingHealth / 2.0f);
        }
    }
}
