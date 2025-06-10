using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataConnector : MonoBehaviour
{
    public static ItemDataConnector Instance { get; private set; }

    [Header("Equip Items")]
    [SerializeField] List<EquipItemScriptable> equipItems = new List<EquipItemScriptable>();
    
    [Header("Equip Items")]
    [SerializeField] List<ConsumableItemScriptable> consumableItems = new List<ConsumableItemScriptable>();
    void Awake()
    {
        if(!Instance) Instance = this;
        else Destroy(this);
    }

    public EquipItem GetRandomEquipItem()
    {
        EquipItem equipItem = new EquipItem();
        
        equipItem.Init(equipItems[Random.Range(0, equipItems.Count)]);
        
        return equipItem;
    }
}
