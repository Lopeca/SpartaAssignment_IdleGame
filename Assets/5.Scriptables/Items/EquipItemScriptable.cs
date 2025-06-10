using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum StatType
{
    HP,
    ATK,
    DEF,
    AS
}

[System.Serializable]
public class Stat
{
    public StatType statType;
    public float value;
    public float upgradeValue;

    public string StatToString()
    {
        return $"{statType.ToString()}: {(int)value}";
    }
}

[CreateAssetMenu(fileName = "Equip Item Data", menuName = "Scriptable/Equip Item")]
public class EquipItemScriptable : ItemScriptableBase
{
    [SerializeField] private List<Stat> stats;
    public List<Stat> Stats => stats;
}
