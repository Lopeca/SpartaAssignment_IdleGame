using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLooper : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private int tileCount;
    private const int tileSize = 150;
    private void OnTriggerEnter(Collider other)
    {
        if ((groundLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            other.transform.position += tileCount * new Vector3(0, 0, tileSize);
        }
    }
}
