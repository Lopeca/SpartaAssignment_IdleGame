using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerFSM _fsm) : base(_player, _fsm)
    {
    }

    public override void Enter()
    {
        // 애니메이션 상태 변화
        player.Animator.SetBool(AnimationStringData.IsMove, true);
        
    }

    public override void Exit()
    {
        player.Animator.SetBool(AnimationStringData.IsMove, true);
    }

    public override void Update()
    {
        
    }
}
