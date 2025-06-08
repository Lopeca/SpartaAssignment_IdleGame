using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public GameObject target;
    [field:SerializeField] public CharacterController CharacterController {get; private set;}
    [field:SerializeField] public Animator Animator {get; private set;}
    private EnemyFSM _enemyFSM;
    
    [field:SerializeField] public float RotationDamping { get; private set; }
    
    private void Awake()
    {
        _enemyFSM = new EnemyFSM(this);
        
        if(!CharacterController)
            CharacterController = GetComponent<CharacterController>();
        
        if(!Animator)
            Animator = GetComponentInChildren<Animator>();

        _enemyFSM.ChangeState(_enemyFSM.enemyIdleState);
    }

    private void Update()
    {
        _enemyFSM.UpdateMachine();
    }

    public bool TargetIsInRange()
    {
        return (target.transform.position - transform.position).sqrMagnitude <= Mathf.Pow(enemyData.Range, 2);
    }
}
