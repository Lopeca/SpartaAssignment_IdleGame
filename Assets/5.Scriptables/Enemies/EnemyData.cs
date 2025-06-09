using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable/Enemy")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public int HP { get; private set; } = 100;
    [field: SerializeField] public int ATK { get; private set; } = 10;
    [field: SerializeField] public int AttackSpeed { get; private set; } = 1;
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5;
    [field: SerializeField] public float Range { get; private set; } = 10;
    [field: SerializeField] public float Deal_Start_Time { get; private set; } = 0.3f;


}
