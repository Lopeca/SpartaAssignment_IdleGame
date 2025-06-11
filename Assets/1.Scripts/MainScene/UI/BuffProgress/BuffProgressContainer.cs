using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffProgressContainer : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject buffIconPrefab;
    
    List<BuffProgressIcon> buffIcons = new List<BuffProgressIcon>();
    void Start()
    {
        container.EmptyChildren();
    }

    public void AddBuff(Buff buff)
    {
        BuffProgressIcon buffIcon = Instantiate(buffIconPrefab, container.transform).GetComponent<BuffProgressIcon>();
        buffIcon.Init(buff);
        buffIcons.Add(buffIcon);
    }

    public void RemoveBuff(Buff buff)
    {
        BuffProgressIcon icon = buffIcons.Find(icon => icon.BuffRef == buff);
        buffIcons.Remove(icon);
        Destroy(icon.gameObject);
    }
}
