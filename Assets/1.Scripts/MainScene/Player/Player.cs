using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public float MoveSpeed { get; private set; }

    [field:SerializeField] public Animator Animator {get; private set;}
    private PlayerFSM _playerFSM;

    private void Awake()
    {
        _playerFSM = new PlayerFSM(this);
        Animator = GetComponentInChildren<Animator>();

        _playerFSM.ChangeState(_playerFSM.playerIdleState);
    }

    private void Update()
    {
        _playerFSM.UpdateMachine();
    }
}
