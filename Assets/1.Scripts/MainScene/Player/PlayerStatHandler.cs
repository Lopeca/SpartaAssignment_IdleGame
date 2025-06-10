using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    // [필드 부피 개선방안]
    // base, bonus 한 세트로 클래스화
    // 스탯 타입으로 딕셔너리나, 인스펙터에서 보려면 리스트
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
    
    Dictionary<string, Buff> buffs = new Dictionary<string, Buff>();
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

    public void CalculateStat()
    {
        ResetBonusStats();

        CalculateItemBonusStat();
        CalculateBuffStat();
        
        UpdateStatUI();
    }

    private void CalculateBuffStat()
    {
        foreach (KeyValuePair<string, Buff> buffDicElement in buffs)
        {
            Buff buff = buffDicElement.Value;
            foreach (BuffProperty property in buff.Data.BuffOptions)
            {
                switch (property.statType)
                {
                    case StatType.ATK:
                        BonusATK += property.value;
                        break;
                    case StatType.DEF:
                        BonusDEF += property.value;
                        break;
                    case StatType.HP:
                        BonusHP += property.value;
                        break;
                    case StatType.AS:
                        BonusAttackSpeed += property.value;
                        break;
                }
            }
        }
    }

    private void CalculateItemBonusStat()
    {
        // 장착중인 아이템을 리스트로 따로 안 빼고 슬롯 보고 돌고 있습니다
        foreach (ItemSlot slot in BattleManager.Instance.player.playerInventory.itemSlots)
        {
            EquipItem equipItem = slot.Item as EquipItem;

            if (equipItem == null) continue;
            if (!equipItem.equipped) continue;

            foreach (Stat stat in equipItem.Stats)
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
    }

    public void UpdateStatUI()
    {
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, TotalHP);
        MainSceneUIManager.Instance?.sidePanel.mainTab.UpdateStatText(TotalATK, TotalDEF, TotalAttackSpeed);
    }

    private void ResetBonusStats()
    {
        BonusATK = 0;
        BonusDEF = 0;
        BonusHP = 0;
        BonusAttackSpeed = 0;
    }

    public void AppendBuff(Buff buff)
    {
        if(buffs.ContainsKey(buff.Data.Name)) buffs[buff.Data.Name].EndBuff();
        buffs.Add(buff.Data.Name, buff);
        CalculateStat();
    }

    public void RemoveBuff(Buff buff)
    {
        buffs.Remove(buff.Data.Name);
        CalculateStat();
    }
}
