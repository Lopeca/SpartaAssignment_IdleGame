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
    
    public int Id => id;
    public Item Item => item;
    public bool IsEmpty => item == null || !item.itemData;

    private void Awake()
    {
        icon.gameObject.SetActive(false);
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(() => MainSceneUIManager.Instance.ShowItemInfo(this));
    }

    public void SetId(int id)
    {
        this.id = id;
    }
    
    public void SetItem(Item _item)
    {
        item = _item;
        icon.sprite = _item.itemData.Icon;
        icon.gameObject.SetActive(true);
        button.interactable = true;
    }

    public void EmptySlot()
    {
        icon.sprite = null;
        item = null;
        icon.gameObject.SetActive(false);
        button.interactable = false;
    }
}
