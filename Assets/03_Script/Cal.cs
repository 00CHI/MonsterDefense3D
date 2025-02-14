using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cal : MonoBehaviour
{
    public StraightArrow Bullet;
    public void OnCollisionEnter(Collision collision)
    {
        Monster monster = collision.transform.GetComponent<Monster>();

        if (monster == null)
        {
            return;
        }
        else if (monster)
        {
            Debug.Log("Monster");
        }
    }
}
