using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager _instance;

    public static BattleManager Instance
    {
        get
        {
            if (_instance) return _instance;
            
            var go = new GameObject("BattleManager");
            go.AddComponent<BattleManager>();
            return go.GetComponent<BattleManager>();
        }
    }

    public Player player;
    private Vector3 playerInitPos;
    [SerializeField] TerrainLooper terrainLooper;
    [SerializeField] private EnemySpawner enemySpawner;
    Coroutine waveCoroutine;
    
    public const int MaxWaveCount = 5;
    private const float waveTerm = 2.5f;
    public int CurrentWaveCount { get; private set; }
    public int remainedEnemies;
    
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (!terrainLooper)
        {
            terrainLooper = FindObjectOfType<TerrainLooper>();
            if(!terrainLooper) Debug.LogError("No terrain looper found");
        }
        if (!player)
        {
            player = FindObjectOfType<Player>();
            if(!player) Debug.LogError("No player found");
        }
        if (!enemySpawner)
        {
            enemySpawner = FindObjectOfType<EnemySpawner>();
            if(!enemySpawner) Debug.LogError("No player found");
        }
        
        playerInitPos = player.transform.position;

        InitBattle();
    }

    public void InitBattle()
    {
        CurrentWaveCount = 1;
        terrainLooper.InitializeTerrain();
        player.transform.position = playerInitPos;
        player.Init();
        remainedEnemies = 0;
        enemySpawner.EmptyContainer();
        if(waveCoroutine != null) StopCoroutine(waveCoroutine);

        NextWave();
    }

    private void NextWave()
    {
        if (CurrentWaveCount <= MaxWaveCount)
        {
            CurrentWaveCount++;
            waveCoroutine = StartCoroutine(SpawnNextWave());
        }
        else
        {
            // 배틀 끝 연출
            StartCoroutine(Loop());
        }
    }

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(2f);
        MainSceneUIManager.Instance.BattleFadeOut();
        yield return new WaitUntil(() => MainSceneUIManager.Instance.fadeComplete);
        
        InitBattle();
        MainSceneUIManager.Instance.BattleFadeIn();
        yield return new WaitUntil(() => MainSceneUIManager.Instance.fadeComplete);
        
    }

    IEnumerator SpawnNextWave()
    {
        yield return new WaitForSeconds(waveTerm);
        enemySpawner.Spawn(2);
    }

    public void EnemyKilled()
    {
        remainedEnemies--;
        if(remainedEnemies == 0) NextWave();
    }
}
