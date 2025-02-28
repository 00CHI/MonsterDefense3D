using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMonster : AiBase
{
    protected override void Search()
    {
        Vector3 targetPos = Shared.Stage.TRPATH[TargetIndex].position;
        float distance = Vector3.Distance(targetPos, Character.transform.position);

        if(distance < 0.1f)
        {
            TargetIndex++;

            if(TargetIndex >= Shared.Stage.TRPATH.Count)
            {
                TargetIndex = 0;
            }
        }
        
        Collider[] playerColl = Physics.OverlapSphere(Character.transform.position, 10f);

        if(playerColl.Length > 0)
        {
            Debug.Log(playerColl.Length);

            //for (int i = 0; i < playerColl.Length;i++)
            //{
                
            //}
        }

        base.Search();
    }

    protected override void Move()
    {
        Vector3 targetPos = Shared.Stage.TRPATH[TargetIndex].position;

        Character.Move(targetPos);

        base.Move();
    }

}

       

