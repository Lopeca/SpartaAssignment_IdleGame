using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public float MoveSpeed { get; private set; }

    public Animator animator;
    private PlayerFSM _playerFSM;

    private void Awake()
    {
        _playerFSM = new PlayerFSM(this);
        animator = GetComponentInChildren<Animator>();
    }
}
