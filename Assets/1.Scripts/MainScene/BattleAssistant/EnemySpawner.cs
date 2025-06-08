using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private Vector3 spawnAreaSize;
    [SerializeField] GameObject enemyContainer;

    private void Awake()
    {
        if (!enemyContainer)
        {
            enemyContainer = new GameObject("EnemyContainer");
        }
    }

    public void Spawn(int count)
    {
        float intervalX = spawnAreaSize.x / (count + 1);
        for (int i = 0; i < count; i++)
        {
            Vector3 offset = new Vector3(intervalX * (i+1), 0, Random.Range(-spawnAreaSize.z /2, spawnAreaSize.z / 2));
            
            Vector3 spawnPos = transform.position - new Vector3(spawnAreaSize.x/2, 0, 0) + offset;
            Enemy enemy = Instantiate(enemies.GetRandom(), spawnPos, Quaternion.Euler(0,180,0), enemyContainer.transform).GetComponent<Enemy>();
            enemy.target = BattleManager.Instance.player.gameObject;
        }
        BattleManager.Instance.remainedEnemies += count; 
    }

    public void EmptyContainer()
    {
        enemyContainer.EmptyChildren();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, spawnAreaSize.y/2, 0), spawnAreaSize);
    }
    
    
}
