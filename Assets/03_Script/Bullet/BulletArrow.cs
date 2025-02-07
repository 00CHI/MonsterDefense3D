using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class BulletArrow : Bullet
{
    private void Awake()
    {
        Shared.BulletArrow = this;
    }


    public void Init(Vector3 _TargetPos, float _Speed)
    {
        TargetPos = _TargetPos;
        Speed = _Speed;

        //Vector3 dir = TargetPos - transform.position;

        //float r = Mathf.Atan2(dir.x, dir.y);

        //float d = r * Mathf.Rad2Deg;

        //if (d < 0)
        //    d += 360;

        //dir.z = d;

        //Quaternion rotation = Quaternion.LookRotation(dir.normalized);

       
        //transform.rotation = Quaternion.Euler(rotation.x, rotation.y , rotation.z);
    }

    protected override void Move()
    {
        //Vector3.Dot();//����
        //Vector3.Cross();//����
        //Vector3.Nomalize();//����ȭ
        //Vector3.Magnitude();//����

        Vector3 dir = Shared.Monster.transform.position - transform.position;

        //float angle = Vector3.Dot(TargetPos, transform.position);

        //dir.x = 90;

        //Quaternion lookTarget =  Quaternion.LookRotation(TargetPos.normalized);

        //transform.rotation = Quaternion.Euler(angle, 0, 0);
        //float radian = Mathf.Atan2(dir.x, dir.y);

        //float degrees = radian * Mathf.Rad2Deg;

      
        //transform.rotation = Quaternion.Euler(0, 0, degrees);
        transform.position += dir * Speed * Time.deltaTime;

        //� 
        //transform.position = Vector3.Lerp(transform.position, TargetPos, Speed * Time.deltaTime);

        //����
        //transform.position = Vector3.Lerp(TargetPos, transform.position, Speed * Time.deltaTime);
    }



}
