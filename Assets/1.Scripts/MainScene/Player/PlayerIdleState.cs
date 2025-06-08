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
        // 스테이지 클리어도 아니고 전투 중도 아니면
        fsm.ChangeState(fsm.playerMoveState);
    }
}
