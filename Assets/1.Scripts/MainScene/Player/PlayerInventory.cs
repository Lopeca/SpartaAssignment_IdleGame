using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public ItemSlot[] itemSlots;
    
    private int _gold;
    public int Gold => _gold;

    private void Awake()
    {
        itemSlots = new ItemSlot[15];
    }
    

    public void AddGold(int amount)
    {
        _gold += amount;
    }

    public void AppendSlot(ItemSlot slot, int i)
    {
        itemSlots[i] = slot;
    }

    public void AddItem(Item item)
    {

        for (int i = 0; i < itemSlots.Length; i++)
        {
            Debug.Log($"i : {i} || {itemSlots[i].IsEmpty}");
            if (itemSlots[i].IsEmpty)
            {
                itemSlots[i].SetItem(item);
                return;
            }
        }
    }

    public void RemoveItem(ItemSlot slot)
    {
        slot.EmptySlot();
        BattleManager.Instance.player.statHandler.CalculateItemStat();
    }
}
