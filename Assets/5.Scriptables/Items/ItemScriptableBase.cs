using UnityEngine;

public class ItemScriptableBase : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;
    [SerializeField] private int cost;
    public string Name => name;
    public Sprite Icon => icon;
    public int Cost => cost;
}