using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    Coroutine detectCoroutine;
    public PlayerMoveState(Player _player, PlayerFSM _fsm) : base(_player, _fsm)
    {
    }

    public override void Enter()
    {
        // 애니메이션 상태 변화
        player.Animator.SetBool(AnimationStringData.IsMove, true);
        detectCoroutine = player.StartCoroutine(DetectTarget());
    }

    public override void Exit()
    {
        player.Animator.SetBool(AnimationStringData.IsMove, false);
        if(detectCoroutine != null) player.StopCoroutine(detectCoroutine);
    }

    public override void Update()
    {
        if (player.target)
        {
            fsm.ChangeState(fsm.playerAttackState);
        }
        player.CharacterController.Move(new Vector3(0,0,player.MoveSpeed) * Time.deltaTime);
    }

    IEnumerator DetectTarget()
    {
        while (!player.target)
        {
            // 구체 형태의 적 감지 영역
            Collider[] results = new Collider[10];
            var size = Physics.OverlapSphereNonAlloc(player.transform.position, player.statHandler.Range, results, player.enemyMask);
            
            if (size > 0)
            {
                // 거리순으로 반응
                var closest = results
                    .Take(size)
                    .OrderBy(h => Vector3.SqrMagnitude(h.transform.position - player.transform.position))
                    .ToArray();

                for (int i = 0; i < size; i++)
                {
                    //거리 안의 상대가 죽어있으면 다음 적 탐색
                    Enemy enemy = closest[i].GetComponent<Enemy>();
                    if (!enemy.IsDead)
                    {
                        player.target = enemy;
                        break;
                    }
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
