using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : StateMachine
{
    public Player player;

    PlayerMoveState _playerMoveState;
    private PlayerAttackState playerAttackState;
    public PlayerFSM(Player _player)
    {
        player = _player;
        _playerMoveState = new PlayerMoveState(player, this);
        playerAttackState = new PlayerAttackState(player, this);
        
        ChangeState(_playerMoveState);
    }
}
