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
            OnDeath();
        }
    }

    void OnDeath()
    {
        
    }


}
