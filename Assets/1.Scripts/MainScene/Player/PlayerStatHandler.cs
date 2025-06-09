using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [field: SerializeField] public float MaxHP { get; private set; } = 100;
    [field: SerializeField] public float ATK { get; private set; } = 15;
    [field: SerializeField] public float DEF { get; private set; } = 0;
    
    [field:SerializeField] public float AttackSpeed { get; private set; }
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
        CurrentHP = MaxHP;
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, MaxHP);
        
    }

    public void ChangeHP(float delta)
    {
        CurrentHP += delta;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, MaxHP);
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, MaxHP);
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
        MaxHP += 70;
        CurrentHP += 100;
        ATK += 10;
        DEF += 5;
        
        MainSceneUIManager.Instance?.battlePanel.UpdateHP(CurrentHP, MaxHP);
        MainSceneUIManager.Instance?.sidePanel.mainTab.UpdateStatText(ATK, DEF);
    }
}
