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
}

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private List<Stat> stats;
    [SerializeField] private int cost;
    public int upgradedCount = 0;

    public Sprite Icon => icon;
    public List<Stat> Stats => stats;
    public int Cost => (int)(cost * (1 + (float)upgradedCount / 2));
}
