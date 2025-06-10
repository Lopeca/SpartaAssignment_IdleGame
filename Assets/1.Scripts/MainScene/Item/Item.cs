using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    [SerializeField] protected ItemScriptableBase itemData;
    public ItemScriptableBase ItemData => itemData;
    public abstract string GetItemInfoString();
}
