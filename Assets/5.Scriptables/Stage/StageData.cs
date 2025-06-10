using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 메모 : 어드레서블 쓸 시 필드 타입 AssetReference
[CreateAssetMenu(fileName = "New Stage Data", menuName = "Scriptable/Stage Data")]
public class StageData : ScriptableObject
{
   [SerializeField] private int id;
   public int Id => id;
   
   [SerializeField] private List<GameObject> monsterPrefabs;
   public List<GameObject> MonsterPrefabs => monsterPrefabs;

   [SerializeField] private List<GameObject> tilingTerrainPrefabs;
   public List<GameObject> TilingTerrainPrefabs => tilingTerrainPrefabs;
}
