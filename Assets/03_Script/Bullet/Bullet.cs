using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public BulletArrow BulletArrow;

    protected Vector3 TargetPos;

    protected float Speed;

    public virtual void Init()
    {
        Speed = 0;
       
    }

    protected virtual void Move()
    {

    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

}
