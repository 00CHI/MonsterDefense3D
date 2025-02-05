using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class BulletArrow : Bullet
{
    //protected Vector3 TargetPos;

    public Quaternion lookTarget;

    private void Awake()
    {
        Shared.BulletArrow = this;
    }
    public void Init(Vector3 _TargetPos, float _Speed)
    {
        TargetPos = _TargetPos;
        Speed = _Speed;
    }

    protected override void Move()
    {
        //Vector3.Dot();//����
        //Vector3.Cross();//����
        //Vector3.Nomalize();//����ȭ
        //Vector3.Magnitude();//����

        Vector3 dir = TargetPos - transform.position;

        dir.y = 0f;

        lookTarget = Quaternion.LookRotation(TargetPos.normalized);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, Time.deltaTime);

        transform.position += dir * Speed * Time.deltaTime;
        //� 
        //transform.position = Vector3.Lerp(transform.position, TargetPos, Speed * Time.deltaTime);
        
        //����
        //transform.position = Vector3.Lerp(TargetPos, transform.position, Speed * Time.deltaTime);
    }
}
