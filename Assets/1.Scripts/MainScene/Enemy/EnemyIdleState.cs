using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy _enemy, EnemyFSM _fsm) : base(_enemy, _fsm)
    {
    }
    public override void Enter()
    {
        enemy.Animator.SetBool(AnimationStringData.IsIdle, true);
    }

    public override void Exit()
    {
        enemy.Animator.SetBool(AnimationStringData.IsIdle, false);

    }

    public override void Update()
    {
        if (enemy.target.IsDead) return;
        
        if (!enemy.TargetIsInRange())
        {
            fsm.ChangeState(fsm.enemyMoveState);
        }
        else
        {
            fsm.ChangeState(fsm.enemyAttackState);
        }
    }
}
