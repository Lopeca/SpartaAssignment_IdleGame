using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] Item item;
    [SerializeField] Image icon;
    [SerializeField] private Button button;
    [SerializeField] private GameObject equipMark;
    
    public int Id => id;
    public Item Item => item;
    public bool IsEmpty => item == null;

    private void Awake()
    {
        icon.gameObject.SetActive(false);
        button = GetComponent<Button>();
        equipMark.SetActive(false);
    }

    private void Start()
    {
        button.onClick.AddListener(() => MainSceneUIManager.Instance.ShowItemInfo(this));
    }

    public void SetId(int id)
    {
        this.id = id;
    }
    
    public void SetItem(Item item)
    {
        this.item = item;
        icon.sprite = item.ItemData.Icon;
        icon.gameObject.SetActive(true);
        button.interactable = true;
    }

    public void UpdateSlot()
    {
        if (item == null)
        {
            EmptySlot();
            return;
        }
        if (item is EquipItem equipItem)
            equipMark.SetActive(equipItem.equipped);
        else
            EmptySlot();
    }
    public void EmptySlot()
    {
        icon.sprite = null;
        item = null;
        icon.gameObject.SetActive(false);
        button.interactable = false;
        equipMark.SetActive(false);
        
    }
}
