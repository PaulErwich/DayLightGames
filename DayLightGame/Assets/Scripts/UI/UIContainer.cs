
using UnityEngine;

public class UIContainer : MonoBehaviour
{
    public void CloseUI()
    {
        gameObject.SetActive(false);
    }

    public void OpenUI()
    {
        gameObject.SetActive(true);
    }
}
