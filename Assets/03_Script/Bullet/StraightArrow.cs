using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightArrow : MonoBehaviour
{
    float Speed;

    private void Awake()
    {
 
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Init(float _Speed)
    {
        Speed = _Speed;
    }
    // Update is called once per frame
    public void Move()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
    public void OnCollisionEnter(Collision collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();

        if (monster == null)
        {
            return;
        }

        
    }

}
