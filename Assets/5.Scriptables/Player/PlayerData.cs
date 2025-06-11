using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New PlayerData", menuName = "Scriptable/Player Data")]
public class PlayerData : ScriptableObject
{
    public int gold;
    public int level;
    public float baseHp;
    public float baseATK;
    public float baseDEF;
    public float baseAS;
    
     
}
