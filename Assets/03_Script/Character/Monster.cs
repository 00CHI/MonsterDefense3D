using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;

public class Monster : Character
{
    private void Awake()
    {
        InitStat();
        Shared.Monster = this;

        ANIMATOR = GetComponent<Animator>();
    }

    private void Update()
    {
        //monsterPos = transform.position;
    }
    public override void CharacterType()
    {
        Type = eCHARACTER.eCHARACTER_MONSTER;
    }

    public override void InitStat()
    {

        Stat[(int)eSTAT.eSTAT_HP] = 200;
        Stat[(int)eSTAT.eSTAT_MP] = 10;
        Stat[(int)eSTAT.eSTAT_ATK] = 10;
        Stat[(int)eSTAT.eSTAT_DEF] = 5;
        Stat[(int)eSTAT.eSTAT_SPEED] = 3;
        Stat[(int)eSTAT.eSTAT_RES] = 5;

        HpMax = Stat[(int)eSTAT.eSTAT_HP];
    }

    //public override void InitItem(ItemBase _Item)
    //{
    //    Item = _Item;
    //}

    public void OnHit(int _OtherAtk)
    {
        if(Stat[(int)eSTAT.eSTAT_HP] > 0)
        {
            int damage = _OtherAtk - Stat[(int)eSTAT.eSTAT_DEF];
            Stat[(int)eSTAT.eSTAT_HP] -= damage;

            Debug.Log(Stat[(int)eSTAT.eSTAT_HP] + "에" + damage + "의 데미지를 입혔습니다.");
        }

        if(Stat[(int)eSTAT.eSTAT_HP] == 0)
        {
        
            ANIMATOR.SetBool("isDie", true);
            
            moveSpeed = 0;
            Invoke("OnDeath", 2f);
         
        }
    }

    void OnDeath()
    {
        gameObject.SetActive(false);
        Transform startPos = Shared.Stage.TRPATH[0];
        Vector3 restartPos = new Vector3(startPos.position.x, startPos.position.y,startPos.position.z);

        transform.position = restartPos;
        Stat[(int)eSTAT.eSTAT_HP] = HpMax;

        Debug.Log(Stat[(int)eSTAT.eSTAT_HP]);
        Invoke("Respawn", 2f);

    }

    void Respawn()
    {
        if (Stat[(int)eSTAT.eSTAT_HP] == HpMax)
        {
            gameObject.SetActive(true);
            ANIMATOR.SetBool("isDie", false);

            moveSpeed = 3f;
        }
    }



}
