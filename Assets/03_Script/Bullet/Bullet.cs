using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public BulletArrow BulletArrow;

    protected Vector3 TargetPos;

    protected float Speed;
    protected float Damage;


    private void Awake()
    {

    }
    public virtual void Init()
    {
        Speed = 0;
        Damage = 1;
    }

    protected virtual void Move()
    {

    }


    protected virtual void FixedUpdate()
    {
        Move();
    }

}
