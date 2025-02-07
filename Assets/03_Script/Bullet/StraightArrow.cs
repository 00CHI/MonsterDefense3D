using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightArrow : Bullet
{
    Rigidbody rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    protected override void Move()
    {
        rigidbody.AddForce(transform.up * Speed, ForceMode.Impulse);
    }
}
