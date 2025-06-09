using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerFSM _fsm) : base(_player, _fsm)
    {
    }

    public override void Enter()
    {
        player.Animator.SetBool(AnimationStringData.IsIdle, true);
    }

    public override void Exit()
    {
        player.Animator.SetBool(AnimationStringData.IsIdle, false);
    }

    public override void Update()
    {
        if(!player.target)
            fsm.ChangeState(fsm.playerMoveState);
        else 
        {
            fsm.ChangeState(fsm.playerAttackState);
        }
    }
}
