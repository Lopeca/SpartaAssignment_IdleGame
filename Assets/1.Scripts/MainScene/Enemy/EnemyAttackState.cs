using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private bool attackApplied;
    public EnemyAttackState(Enemy _enemy, EnemyFSM _fsm) : base(_enemy, _fsm)
    {
    }
    public override void Enter()
    {
        attackApplied = false;
        enemy.Animator.SetBool(AnimationStringData.IsAttack, true);
        
        fsm.attackCoroutine = enemy.StartCoroutine(Attack());
        enemy.Animator.speed = enemy.enemyData.AttackSpeed;
        
    }

    public override void Exit()
    {
        enemy.Animator.SetBool(AnimationStringData.IsAttack, false);
        if(fsm.attackCoroutine != null) enemy.StopCoroutine(fsm.attackCoroutine);
        enemy.Animator.speed = 1;
    }

    public override void Update()
    {
        if (attackApplied)
        {
            fsm.ChangeState(fsm.enemyIdleState);
        }
    }
    
    IEnumerator Attack()
    {
        while (enemy.target)
        {
            yield return new WaitForSeconds(enemy.enemyData.Deal_Start_Time / enemy.enemyData.AttackSpeed);
            enemy.target.TakeDamage(enemy.enemyData.ATK);
            yield return new WaitForSeconds((1 - enemy.enemyData.Deal_Start_Time) / enemy.enemyData.AttackSpeed);
            attackApplied = true;
        }
    }
}
