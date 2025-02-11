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
        //Vector3.Dot();//내적
        //Vector3.Cross();//외적
        //Vector3.Nomalize();//정규화
        //Vector3.Magnitude();//길이

        transform.LookAt(Shared.Monster.transform.position);

        Vector3 dir = Shared.Monster.transform.position - transform.position;

        transform.position += dir * Speed * Time.deltaTime;

        //곡선 
        //transform.position = Vector3.Lerp(transform.position, TargetPos, Speed * Time.deltaTime);

        //선형
        //transform.position = Vector3.Lerp(TargetPos, transform.position, Speed * Time.deltaTime);
    }

    protected override void Attack()
    {
        base.Attack();

        Collider monsterCollider = Shared.Monster.GetComponent<Collider>();

        if(monsterCollider)
        {
            Shared.Monster.Stat[(int)eSTAT.eSTAT_HP] -= Shared.Player.Stat[(int)eSTAT.eSTAT_ATK];
        }
        else if (!monsterCollider)
        {
            gameObject.SetActive(false);
        }

    }


}
