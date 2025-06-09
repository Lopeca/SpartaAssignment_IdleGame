using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int _gold;
    public int Gold => _gold;

    public void AddGold(int amount)
    {
        _gold += amount;
    }
}
