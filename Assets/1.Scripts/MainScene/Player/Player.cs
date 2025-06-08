using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public float MoveSpeed { get; private set; }
    [field:SerializeField] public float RotationDamping { get; private set; }

    [field:SerializeField] public CharacterController CharacterController {get; private set;}
    
    [field:SerializeField] public Animator Animator {get; private set;}
    private PlayerFSM _playerFSM;
    private PlayerStatHandler statHandler;
    

    private void Awake()
    {
        _playerFSM = new PlayerFSM(this);
        
        if(!CharacterController)
            CharacterController = GetComponent<CharacterController>();
        
        if(!Animator)
            Animator = GetComponentInChildren<Animator>();

        statHandler = GetComponent<PlayerStatHandler>();
        if (!statHandler)
        {
            statHandler = gameObject.AddComponent<PlayerStatHandler>();
        }

        _playerFSM.ChangeState(_playerFSM.playerIdleState);
    }

    private void Update()
    {
        _playerFSM.UpdateMachine();
    }

    public void TakeDamage(float damage)
    {
        statHandler.ChangeHP(-damage);
    }
}
