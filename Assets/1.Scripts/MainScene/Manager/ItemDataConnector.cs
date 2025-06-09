using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataConnector : MonoBehaviour
{
    public static ItemDataConnector Instance { get; private set; }

    [SerializeField] List<ItemData> items = new List<ItemData>();
    void Awake()
    {
        if(!Instance) Instance = this;
        else Destroy(this);
    }

    public Item GetRandomItem()
    {
        Item item = new Item();
        
        item.Init(items[Random.Range(0, items.Count)]);
        
        return item;
    }
}
