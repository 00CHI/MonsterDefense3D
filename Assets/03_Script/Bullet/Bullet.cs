using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public virtual void Init()
    {

    }

    protected virtual void Move()
    {

    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

}
