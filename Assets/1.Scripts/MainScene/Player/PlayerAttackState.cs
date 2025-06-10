using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    
    private bool attackApplied;
    
    public PlayerAttackState(Player _player, PlayerFSM _fsm) : base(_player, _fsm)
    {
    }

    // Update is called once per frame
    public override void Enter()
    {
        attackApplied = false;
        player.Animator.SetBool(AnimationStringData.IsAttack, true);

        fsm.attackCoroutine = player.StartCoroutine(Attack());
        player.Animator.speed = player.statHandler.TotalAttackSpeed;
    }

    public override void Exit()
    {
        player.Animator.SetBool(AnimationStringData.IsAttack, false);
        if(fsm.attackCoroutine != null) player.StopCoroutine(fsm.attackCoroutine);
        player.Animator.speed = 1;
        
    }

    public override void Update()
    {
        if (attackApplied)
        {
            fsm.ChangeState(fsm.playerIdleState);
        }
        
    }

    IEnumerator Attack()
    {
        while (player.target)
        {
            yield return new WaitForSeconds(player.statHandler.Deal_Start_Time / player.statHandler.TotalAttackSpeed);
            player.target.TakeDamage(player.statHandler.TotalATK);
            yield return new WaitForSeconds((1 - player.statHandler.Deal_Start_Time) / player.statHandler.TotalAttackSpeed);
            attackApplied = true;
            
            // 타겟이 죽음으로 인해서 
            if (player.target.IsDead)
            {
                player.GainGold(player.target.enemyData.Gold);
                player.GainExp(player.target.enemyData.EXP);
                player.target = null;
            }
        }
    }
}
