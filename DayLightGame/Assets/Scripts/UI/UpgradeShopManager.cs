using UnityEngine;
using System.Collections.Generic;

public class UpgradeShopManager : MonoBehaviour
{
    int upgradeNumber = 3;
    public GameObject weaponUpgradeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void SetupUpgradeShop(weaponType _type, upgradeType _upgradeType)
    {
        Debug.Log("Transform child count before: " + transform.childCount);
        SetupWeaponUpgrade.currentUpgradeOptions = new List<int>();
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                Debug.Log("Transform child count: " + transform.childCount);
                Destroy(child.gameObject);
            }
        }
        for (int i = 0; i < upgradeNumber; i++)
        {
            GameObject newUI = Instantiate(weaponUpgradeUI, this.transform);
            newUI.GetComponent<SetupWeaponUpgrade>().SetupUpgradeIcon(_type, _upgradeType);
        }
    }
}
