using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightArrow : Bullet
{
    float Speed;
    int Damage;

    

    private void Awake()
    {
 
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Init(float _Speed, int _Damage)
    {
        Speed = _Speed;
        Damage = _Damage;
    }

    // Update is called once per frame
    public void Move()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
        StartCoroutine(SetFalse(gameObject));
    }

    public void OnTriggerEnter(Collider other)
    {
        Monster monster = other.transform.GetComponent<Monster>();

        if (monster == null)
        {
            return;
        }
        else if (monster)
        {
            Shared.Monster.OnHit(Shared.Player.Stat[(int)eSTAT.eSTAT_ATK]);
            Destroy(gameObject);
            //Debug.Log("Monster");
        }
    }

    public IEnumerator SetFalse(GameObject _GameObject)
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);

    }



}
