using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BuffProgressIcon : MonoBehaviour
{
    private Buff buffRef;
    public Buff BuffRef => buffRef;
    [SerializeField] private Image icon;
    [SerializeField] private Image progressGage;

    public void Init(Buff buffRef)
    {
        this.buffRef = buffRef;
        icon.sprite = buffRef.Data.Icon;
    }

    private void Update()
    {
        ShowProgress(buffRef.GetProgressPercent());
    }

    public void ShowProgress(float progressPercent)
    {
        progressGage.fillAmount = progressPercent;
    }
}
