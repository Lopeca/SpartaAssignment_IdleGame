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

    [SerializeField] private Player player;
    private Vector3 playerInitPos;
    [SerializeField] TerrainLooper terrainLooper;
        
    public const int MaxWaveCount = 5;
    public int CurrentWaveCount { get; private set; }

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
        playerInitPos = player.transform.position;

        InitBattle();
    }

    public void InitBattle()
    {
        CurrentWaveCount = 1;
        terrainLooper.InitializeTerrain();
        player.transform.position = playerInitPos;
    }
}
