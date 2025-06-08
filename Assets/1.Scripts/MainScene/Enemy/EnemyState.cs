using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : IState
{
    protected Enemy enemy;
    protected EnemyFSM fsm;
    
    protected EnemyState(Enemy _enemy, EnemyFSM _fsm)
    {
        enemy = _enemy;
        fsm = _fsm;
    }
    public abstract void Enter();

    public abstract void Exit();
 
    public abstract void Update();
}
