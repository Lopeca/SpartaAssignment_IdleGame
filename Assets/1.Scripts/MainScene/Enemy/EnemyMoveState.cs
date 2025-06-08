using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(Enemy _enemy, EnemyFSM _fsm) : base(_enemy, _fsm)
    {
    }

    public override void Enter()
    {
        enemy.Animator.SetBool(AnimationStringData.IsMove, true);
    }

    public override void Exit()
    {
        enemy.Animator.SetBool(AnimationStringData.IsMove, false);

    }

    public override void Update()
    {
        if (enemy.TargetIsInRange())
        {
            fsm.ChangeState(fsm.enemyIdleState);
        }
        Vector3 direction = (enemy.target.transform.position - enemy.transform.position).normalized;
        enemy.CharacterController.Move(direction * (enemy.enemyData.MoveSpeed * Time.deltaTime));
        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, enemy.RotationDamping * Time.deltaTime);
        
    }
}
