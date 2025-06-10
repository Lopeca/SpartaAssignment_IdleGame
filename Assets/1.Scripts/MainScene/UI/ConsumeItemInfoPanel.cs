using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeItemInfoPanel : MonoBehaviour
{
    [SerializeField] private ItemSlot itemSlot;
    
    [SerializeField] private ConsumableItem item;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI statInfo;
    [SerializeField] private TextMeshProUGUI sellButtonText;
    
    public void SetInfo(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        item = itemSlot.Item as ConsumableItem;
        itemName.text = item.ConsumableItemData.Name;

        UpdateInfo();
    }

    private void UpdateInfo()
    {
        icon.sprite = item.ConsumableItemData.Icon;
        statInfo.text = item.GetItemInfoString();

        sellButtonText.text = $"Sell({item.Cost}G)";
    }

    public void OnClickUseButton()
    {
        item.Use(BattleManager.Instance.player);
        itemSlot.EmptySlot();
        gameObject.SetActive(false);
    }
  
    public void OnClickQuitButton()
    {
        gameObject.SetActive(false);
    }
    
    public void OnClickSellButton()
    {
        gameObject.SetActive(false);
        BattleManager.Instance.player.GainGold(item.Cost);
        BattleManager.Instance.player.playerInventory.RemoveItem(itemSlot);
        itemSlot.UpdateSlot();
    }
    
    
}
