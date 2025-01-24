using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class BulletArrow : Bullet
{
    //protected Vector3 TargetPos;

    Quaternion lookTarget;

    public void Init(Vector3 _TargetPos, float _Speed)
    {
        TargetPos = _TargetPos;

        Speed = _Speed;
    }

    protected override void Move()
    {

        Vector3 dir = TargetPos - transform.position;

        transform.position += dir * Speed * Time.deltaTime;

        //°î¼± 
        transform.position = Vector3.Slerp(transform.position, TargetPos, Speed * Time.deltaTime);

        lookTarget = Quaternion.LookRotation(dir).normalized;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.1f);
        
        //¼±Çü
        //transform.position = Vector3.Lerp(TargetPos, transform.position, Speed * Time.deltaTime);
    }
}
