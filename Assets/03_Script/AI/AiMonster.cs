using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiMonster : AiBase
{
    protected override void Search()
    {
        Vector3 targetPos = Shared.Stage.TRPATH[TargetIndex].position;

        float distance = Vector3.Distance(targetPos, Character.transform.position);

        if (distance < 0.1f)
        {
            TargetIndex++;

            if(TargetIndex >= Shared.Stage.TRPATH.Count)
            {
                TargetIndex = 0;
            }
        }
        base.Search();
    }


    protected override void Move()
    {
        Vector3 targetPos = Shared.Stage.TRPATH[TargetIndex].position;
        Vector3 playerPos = Shared.Player.transform.position;

        float playerDistance = Vector3.Distance(playerPos, Character.transform.position);

        //몬스터의 시야거리 체크 
        if (playerDistance <= 5f && playerDistance >= 1.5f)
        {
            //몬스터 <=> 플레이어 공격거리
            Character.Move(playerPos);
            Shared.Monster.ANIMATOR.SetBool("isAttack", false);

        }
        else if(playerDistance <= 1.5f)
        {
            Attack();
        }
        else if(playerDistance > 5f)
        {
            Character.Move(targetPos);
            Shared.Monster.ANIMATOR.SetBool("isAttack", false);
        }


        base.Move();
    }

    protected override void Attack()
    {
        Shared.Monster.OnAttack();

        base.Attack();
    }


}

       

