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

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private List<Stat> stats;
    [SerializeField] private int cost;

    public string Name => name;
    public Sprite Icon => icon;
    public List<Stat> Stats => stats;
    public int Cost => cost;
    
}
