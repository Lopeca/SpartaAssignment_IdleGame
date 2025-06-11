using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public int level = 1;
    public int exp = 0;
    public float baseHp = 4000;
    public float baseATK = 120;
    public float baseDEF = 2;

    public int gold = 5;
    public List<Item> items;

    private void Awake()
    {
        items = new List<Item>();
    }

    public void Save(Player player)
    {
        level = player.statHandler.CurrentLevel;
        exp = player.statHandler.CurrentEXP;
        baseHp = player.statHandler.BaseHP;
        baseATK = player.statHandler.BaseATK;
        baseDEF = player.statHandler.BaseDEF;

        gold = player.playerInventory.Gold;
        
        items.Clear();
        foreach (ItemSlot slot in player.playerInventory.itemSlots)
        {
            if(slot.Item != null) items.Add(slot.Item);
        }
    }
}
