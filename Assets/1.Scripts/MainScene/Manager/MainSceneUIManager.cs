using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public static MainSceneUIManager Instance { get; private set; }

    public BattlePanel battlePanel;
    public SidePanel sidePanel;
    public ItemInfoPanel itemInfoPanel;
    

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        itemInfoPanel.gameObject.SetActive(false);
    }

    public void ShowItemInfo(ItemSlot itemSlot)
    {
        itemInfoPanel.SetInfo(itemSlot);
        itemInfoPanel.gameObject.SetActive(true);
    }
}
