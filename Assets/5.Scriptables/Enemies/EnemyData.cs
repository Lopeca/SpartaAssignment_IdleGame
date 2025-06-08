using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable/Enemy")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public int ATK { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float Range { get; private set; }
    
}
