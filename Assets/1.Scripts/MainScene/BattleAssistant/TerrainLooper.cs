using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLooper : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private int tileCount;
    [SerializeField] private GameObject terrainContainer;

    Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();
    private const int tileSize = 150;

    public void CreateTerrain()
    {
        terrainContainer.EmptyChildren();

        List<GameObject> terrainPrefabs = GameManager.Instance.CurrentStage.TilingTerrainPrefabs;

        for (int i = 0; i < tileCount; i++)
        {
            GameObject targetPrefab = terrainPrefabs.GetRandom();
            Vector3 targetPosition = i * new Vector3(0, 0, 150);

            GameObject go = Instantiate(targetPrefab, targetPosition, Quaternion.identity, terrainContainer.transform);

            originalPositions.Add(go, targetPosition);
        }
    }

    public void InitializeTerrain()
    {
        foreach (var originalPosition in originalPositions)
        {
            GameObject go = originalPosition.Key;
            Vector3 pos = originalPosition.Value;

            go.transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((groundLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            if (!originalPositions.ContainsKey(other.gameObject))
            {
                originalPositions.Add(other.gameObject, other.gameObject.transform.position);
            }

            other.transform.position += tileCount * new Vector3(0, 0, tileSize);
        }
    }
}