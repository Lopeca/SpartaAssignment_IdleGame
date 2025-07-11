using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public static MainSceneUIManager Instance { get; private set; }

    public BattlePanel battlePanel;
    public SidePanel sidePanel;
    public EquipItemInfoPanel equipItemInfoPanel;
    public ConsumeItemInfoPanel consumeItemInfoPanel;

    public BuffProgressContainer buffProgressContainer;

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
        
        equipItemInfoPanel.gameObject.SetActive(false);
        consumeItemInfoPanel.gameObject.SetActive(false);
    }

    public void ShowItemInfo(ItemSlot itemSlot)
    {
        if (itemSlot.Item is EquipItem)
        {
            equipItemInfoPanel.SetInfo(itemSlot);
            equipItemInfoPanel.gameObject.SetActive(true);
        }

        if (itemSlot.Item is ConsumableItem)
        {
            consumeItemInfoPanel.SetInfo(itemSlot);
            consumeItemInfoPanel.gameObject.SetActive(true);
        }
    }
    
    // 특수 버튼 기능 임시로 매니저에게 역할 맡김
    public void OnClickGotoStageBtn()
    {
        GameManager.Instance.playerDataManager.Save(BattleManager.Instance.player);
        SceneManager.LoadScene("StageSelectScene");
    }
}
