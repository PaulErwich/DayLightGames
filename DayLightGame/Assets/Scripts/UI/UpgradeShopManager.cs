using UnityEngine;

public class UpgradeShopManager : MonoBehaviour
{
    int upgradeNumber = 3;
    public GameObject weaponUpgradeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < upgradeNumber; i++)
        {
            GameObject newUI = Instantiate(weaponUpgradeUI, this.transform);
            newUI.GetComponent<SetupWeaponUpgrade>().SetupUpgradeIcon(weaponType.melee, upgradeType.addon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
