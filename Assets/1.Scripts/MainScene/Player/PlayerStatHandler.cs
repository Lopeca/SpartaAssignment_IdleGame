using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [field: SerializeField] public float MaxHP { get; private set; } = 100;
    [field: SerializeField] public float ATK { get; private set; } = 15;
    [field:SerializeField] public float AttackSpeed { get; private set; }
    [field:SerializeField] public float Range { get; private set; }
    [field:SerializeField] public float Deal_Start_Time { get; private set; }

    [field: SerializeField] public float CurrentHP { get; private set; }

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        CurrentHP = MaxHP;
    }

    public void ChangeHP(float delta)
    {
        CurrentHP += delta;
        CurrentHP = Mathf.Clamp(CurrentHP, 0f, MaxHP);
    }
}
