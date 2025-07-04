using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : StateMachine
{
    public Enemy enemy;

    public EnemyIdleState enemyIdleState;
    public EnemyMoveState enemyMoveState;
    public EnemyAttackState enemyAttackState;

    public Coroutine attackCoroutine;
    public EnemyFSM(Enemy _enemy)
    {
        enemy = _enemy;

        enemyIdleState = new EnemyIdleState(enemy, this);
        enemyMoveState = new EnemyMoveState(enemy, this);
        enemyAttackState = new EnemyAttackState(enemy, this);;
    }

    public override void StopMachine()
    {
        if(attackCoroutine != null) enemy.StopCoroutine(attackCoroutine);
    }
}
