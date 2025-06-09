using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public Player target;
    [field:SerializeField] public CharacterController CharacterController {get; private set;}
    [field:SerializeField] public Animator Animator {get; private set;}
    private EnemyFSM _enemyFSM;
    
    [field:SerializeField] public float RotationDamping { get; private set; }
    
    [field:SerializeField] public float CurrentHP { get; private set; }
    [field:SerializeField] public bool IsDead { get; private set; }
    
    
    
    private void Awake()
    {
        _enemyFSM = new EnemyFSM(this);
        
        if(!CharacterController)
            CharacterController = GetComponent<CharacterController>();
        
        if(!Animator)
            Animator = GetComponentInChildren<Animator>();

        CurrentHP = enemyData.HP;

        _enemyFSM.ChangeState(_enemyFSM.enemyIdleState);
        IsDead = false;
    }

    private void Update()
    {
        _enemyFSM.UpdateMachine();
    }

    public bool TargetIsInRange()
    {
        return (target.transform.position - transform.position).sqrMagnitude <= Mathf.Pow(enemyData.Range, 2);
    }

    public void TakeDamage(float playerAtk)
    {
        CurrentHP -= playerAtk;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, enemyData.HP);

        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Animator.SetTrigger(AnimationStringData.IsDie);

        BattleManager.Instance.EnemyKilled();
        IsDead = true;
        enabled = false;
        CharacterController.enabled = false;

        _enemyFSM.StopMachine();

        StartCoroutine(CleanUpCorpse());
    }

    IEnumerator CleanUpCorpse()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
