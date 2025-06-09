using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : StateMachine
{
    public Player player;

    public PlayerIdleState playerIdleState;
    public PlayerMoveState playerMoveState;
    public PlayerAttackState playerAttackState;
    
    public Coroutine attackCoroutine;
    public PlayerFSM(Player _player)
    {
        player = _player;

        playerIdleState = new PlayerIdleState(player, this);
        playerMoveState = new PlayerMoveState(player, this);
        playerAttackState = new PlayerAttackState(player, this);
    }

    public override void StopMachine()
    {
        if (attackCoroutine != null) player.StopCoroutine(attackCoroutine);
    }
}
