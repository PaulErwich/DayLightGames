using UnityEngine;

public class ShopManager : MonoBehaviour
{
    int statUpgradeCount = 4;
    public GameObject shopUpgradePrefab;
    public Texture2D temp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < statUpgradeCount; i++)
        {
            //GameObject tempBox = Instantiate(shopUpgradePrefab, this.transform);
            //tempBox.AddComponent<SetupShopElement>(shopUpgradeTier.COMMON, shopUpgradeType.ARMOUR, 10, temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
