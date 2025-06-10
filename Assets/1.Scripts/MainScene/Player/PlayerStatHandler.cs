using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [field: SerializeField] public float BaseHP { get; private set; } = 100;
    [field: SerializeField] public float BonusHP { get; private set; } = 0;
    
    public float TotalHP => BaseHP + BonusHP;
    
    [field: SerializeField] public float BaseATK { get; private set; } = 15;
    [field: SerializeField] public float BonusATK { get; private set; } = 0;
    public float TotalATK => BaseATK + BonusATK;
    
    [field: SerializeField] public float BaseDEF { get; private set; } = 0;
    [field: SerializeField] public float BonusDEF { get; private set; } = 0;
    public float TotalDEF => BaseDEF + BonusDEF;
    
    [field:SerializeField] public float BaseAttackSpeed { get; private set; }
    [field:SerializeField] public float BonusAttackSpeed { get; private set; }
    public float TotalAttackSpeed => BaseAttackSpeed + BonusAttackSpeed;
    [field:SerializeField] public float Range { get; private set; }
    [field:SerializeField] public float Deal_Start_Time { get; private set; }

    [field: SerializeField] public float CurrentHP { get; private set; }
    [field: SerializeField] public int CurrentLevel { get; private set; }
    
    [field: SerializeField] public int CurrentEXP { get; private set; }
    public int MaxEXP => (int)(Mathf.Pow(CurrentLevel, 1.5f) * 50);
    
    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        CurrentHP = TotalHP;
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, TotalHP);
        
    }

    public void ChangeHP(float delta)
    {
        CurrentHP += delta;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, TotalHP);
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, TotalHP);
    }

    public void GainEXP(int exp)
    {
        CurrentEXP += exp;
        if (CurrentEXP >= MaxEXP)
        {
            CurrentEXP -= MaxEXP;

            LevelUp();
        }
    }

    private void LevelUp()
    {
        CurrentLevel++;
        BaseHP += 70;
        CurrentHP += 100;
        BaseATK += 10;
        BaseDEF += 5;
        
        UpdateStatUI();

    }

    public void CalculateItemStat()
    {
        ResetBonusStats();
        
        foreach (ItemSlot slot in BattleManager.Instance.player.playerInventory.itemSlots)
        {
            Item item = slot.Item;

            if (item == null) continue;
            if (!item.equipped) continue;

            foreach (Stat stat in item.Stats)
            {
                switch (stat.statType)
                {
                    case StatType.ATK:
                        BonusATK += stat.value;
                        break;
                    case StatType.DEF:
                        BonusDEF += stat.value;
                        break;
                    case StatType.HP:
                        BonusHP += stat.value;
                        break;
                    case StatType.AS:
                        BonusAttackSpeed += stat.value;
                        break;
                }
            }
        }
        
        UpdateStatUI();
    }

    public void UpdateStatUI()
    {
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, TotalHP);
        MainSceneUIManager.Instance?.sidePanel.mainTab.UpdateStatText(TotalATK, TotalDEF);
    }

    private void ResetBonusStats()
    {
        BonusATK = 0;
        BonusDEF = 0;
        BonusHP = 0;
        BonusAttackSpeed = 0;
    }
}
