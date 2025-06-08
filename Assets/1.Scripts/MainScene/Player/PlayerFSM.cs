using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : StateMachine
{
    public Player player;

    public PlayerIdleState playerIdleState;
    public PlayerMoveState playerMoveState;
    public PlayerAttackState playerAttackState;
    public PlayerFSM(Player _player)
    {
        player = _player;

        playerIdleState = new PlayerIdleState(player, this);
        playerMoveState = new PlayerMoveState(player, this);
        playerAttackState = new PlayerAttackState(player, this);
    }
}
