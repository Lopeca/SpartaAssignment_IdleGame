using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI statInfo;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    public void SetInfo(ItemSlot itemSlot)
    {
        item = itemSlot.Item;
        itemName.text = item.itemData.Name;

        UpdateInfo();
        
    }

    private void UpdateInfo()
    {
        icon.sprite = item.itemData.Icon;
        statInfo.text = item.GetItemInfoString();
        upgradeCost.text = $"Upgrade({item.Cost.ToString()})";
    }

    public void OnClickUpgradeButton()
    {
        if (BattleManager.Instance.player.playerInventory.Gold < item.Cost) return;
        
        BattleManager.Instance.player.GainGold(-item.Cost);
        item.Upgrade();
        UpdateInfo();
    }
    
    public void OnClickQuitButton()
    {
        gameObject.SetActive(false);
    }
}
