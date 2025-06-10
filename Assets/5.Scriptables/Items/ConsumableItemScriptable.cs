using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumeType
{
    Recover,
    Buff
}

public class ConsumableItemScriptable : ItemScriptableBase
{
    [SerializeField] ConsumeType consumeType;
    public ConsumeType ConsumeType => consumeType;

    [SerializeField] private int value;
    public int Value => value;
    
    [Header("Buff Properties")]
    [SerializeField] StatType statType;
    public StatType StatType => statType;
    [SerializeField] private float duration;
    public float Duration => duration;
}


