using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemInfoPanel : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    
    [SerializeField] private EquipItem equipItem;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI statInfo;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    [SerializeField] private TextMeshProUGUI equipButtonText;
    [SerializeField] private TextMeshProUGUI sellButtonText;
    
    public void SetInfo(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        equipItem = itemSlot.Item as EquipItem;
        itemName.text = equipItem.EquipItemData.Name;

        UpdateInfo();
        
    }

    private void UpdateInfo()
    {
        icon.sprite = equipItem.EquipItemData.Icon;
        statInfo.text = equipItem.GetItemInfoString();
        upgradeCost.text = $"Upgrade({equipItem.Cost.ToString()})";
        equipButtonText.text = equipItem.equipped ? "Unequip" : "Equip";
        sellButtonText.text = $"Sell({equipItem.Cost}G)";
    }

    public void OnClickUpgradeButton()
    {
        if (BattleManager.Instance.player.playerInventory.Gold < equipItem.Cost) return;
        
        BattleManager.Instance.player.GainGold(-equipItem.Cost);
        equipItem.Upgrade();
        BattleManager.Instance.player.statHandler.CalculateStat();
        UpdateInfo();
    }
    public void OnClickEquipButton()
    {
        equipItem.equipped = !equipItem.equipped;
        itemSlot.UpdateSlot();
        BattleManager.Instance.player.statHandler.CalculateStat();
        UpdateInfo();
        
    }
    public void OnClickQuitButton()
    {
        gameObject.SetActive(false);
    }
    
    public void OnClickSellButton()
    {
        gameObject.SetActive(false);
        BattleManager.Instance.player.GainGold(equipItem.Cost);
        BattleManager.Instance.player.playerInventory.RemoveItem(itemSlot);
        itemSlot.UpdateSlot();
    }
    
    
}
