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

        base.Search();
    }

    protected override void Move()
    {
        base.Move();
    }
}

       

