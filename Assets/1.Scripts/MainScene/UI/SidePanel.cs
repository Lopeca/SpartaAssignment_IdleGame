using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SidePanel : MonoBehaviour
{
    public MainTab mainTab;
    public ShopTab shopTab;

    public void OnClickMainButton()
    {
        mainTab.gameObject.SetActive(true);
        shopTab.gameObject.SetActive(false);
    }

    public void OnClickShopButton()
    {
        shopTab.gameObject.SetActive(true);
        mainTab.gameObject.SetActive(false);
    }
}
