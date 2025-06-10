using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumeType
{
    Recover,
    Buff
}

[System.Serializable]
public struct BuffProperty
{
    public StatType statType;
    public float value;

    public override string ToString()
    {
        return statType + " +" + value;
    }
}

[CreateAssetMenu(fileName = "Consumable Item Data", menuName = "Scriptable/Consumable Item")]

public class ConsumableItemScriptable : ItemScriptableBase
{
    [SerializeField] ConsumeType consumeType;
    public ConsumeType ConsumeType => consumeType;

    [SerializeField] private int value;
    public int Value => value;
    
    [Header("Buff Properties")]
    [SerializeField] List<BuffProperty> buffOptions;
    public List<BuffProperty> BuffOptions => buffOptions;
    [SerializeField] private float duration;
    public float Duration => duration;
}