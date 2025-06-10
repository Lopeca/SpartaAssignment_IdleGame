using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable/Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private int hp = 100;
    [SerializeField] private int atk = 10;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float range = 10;
    [SerializeField] private float dealStartTime = 0.3f;

    [Header("Rewards")]
    [SerializeField] private int gold;
    [SerializeField] private int exp;

    public int HP => hp;
    public int ATK => atk;
    public float AttackSpeed => attackSpeed;
    public float MoveSpeed => moveSpeed;
    public float Range => range;
    public float Deal_Start_Time => dealStartTime;
    public int Gold => gold;
    public int EXP => exp;
}
