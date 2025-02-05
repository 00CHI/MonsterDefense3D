using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Monster : Character
{  

    private void Awake()
    {
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

    //public override void InitItem(ItemBase _Item)
    //{
    //    Item = _Item;
    //}
}
