using UnityEngine;

public class UISpriteDictionary : MonoBehaviour
{
    public static UISpriteDictionary instance;

    public Sprite[] bowUpgradeIcons;
    public Sprite[] swordUpgradeIcons;
    public Sprite[] specialUpgradeIcons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
