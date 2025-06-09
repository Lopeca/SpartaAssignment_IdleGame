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
    public PlayerStatHandler statHandler;
    
    [field:SerializeField] public LayerMask enemyMask {get; private set;}
    public Enemy target;
    
    public bool IsDead {get; private set;}
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

        Init();
    }

    public void Init()
    {
        IsDead = false;
        target = null;
        _playerFSM.ChangeState(_playerFSM.playerIdleState);
    }

    private void Update()
    {
        _playerFSM.UpdateMachine();
    }

    public void TakeDamage(float damage)
    {
        statHandler.ChangeHP(-damage);

        if (statHandler.CurrentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        IsDead = true;
        Animator.SetTrigger(AnimationStringData.IsDie);
        enabled = false;
        _playerFSM.StopMachine();
    }
}
