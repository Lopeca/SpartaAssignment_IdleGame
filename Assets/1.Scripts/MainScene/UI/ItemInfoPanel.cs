using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    
    [SerializeField] private Item item;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI statInfo;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    [SerializeField] private TextMeshProUGUI equipText;
    
    public void SetInfo(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        item = itemSlot.Item;
        itemName.text = item.itemData.Name;

        UpdateInfo();
        
    }

    private void UpdateInfo()
    {
        icon.sprite = item.itemData.Icon;
        statInfo.text = item.GetItemInfoString();
        upgradeCost.text = $"Upgrade({item.Cost.ToString()})";
        equipText.text = item.equipped ? "Unequip" : "Equip";
    }

    public void OnClickUpgradeButton()
    {
        if (BattleManager.Instance.player.playerInventory.Gold < item.Cost) return;
        
        BattleManager.Instance.player.GainGold(-item.Cost);
        item.Upgrade();
        BattleManager.Instance.player.statHandler.CalculateItemStat();
        UpdateInfo();
    }
    public void OnClickEquipButton()
    {
        item.equipped = !item.equipped;
        itemSlot.UpdateSlot();
        BattleManager.Instance.player.statHandler.CalculateItemStat();
        UpdateInfo();
        
    }
    public void OnClickQuitButton()
    {
        gameObject.SetActive(false);
    }
    
    public void OnClickDiscardButton()
    {
        gameObject.SetActive(false);
        BattleManager.Instance.player.playerInventory.RemoveItem(itemSlot);
        itemSlot.UpdateSlot();
    }
    
    
}
