using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightArrow : Bullet
{
    bool isMonster = false;

    private void Awake()
    {
    }
    public void Init(float _Speed)
    {
        Speed = _Speed;
    }
    // Update is called once per frame
    protected override void Move()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    

}
