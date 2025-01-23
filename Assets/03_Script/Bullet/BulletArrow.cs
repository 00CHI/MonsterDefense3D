using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArrow : Bullet
{
    protected Vector3 TargetPos;
    //protected Vector3 
    public void Init(Vector3 _TargetPos, float _Speed)
    {
        TargetPos = _TargetPos;
    }

    protected override void Move()
    {
        //°î¼± 
        //
        //Vector3.Slerp(Vector3.zero, )
    }
}
