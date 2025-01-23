using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract partial class Character : MonoBehaviour
{
    public AiBase AI;

    public Animator ANIMATOR;

    Quaternion lookTarget;

    public eCHARACTER Type;


    float moveSpeed = 3f;
    public int HpMax;
    public int[] Stat = new int[(int)eSTAT.eSTAT_END];


    public abstract void CharacterType();

    public virtual void InitItem(ItemBase _Item) { }

// Start is called before the first frame update
    void Start()
    {
        if (AI != null)
        {
            AI.Init(this);
        }
    }

    private void FixedUpdate()
    {
        if (AI == null)
        {
            return;
        }

        AI.State();
    }

    public virtual void Init()
    {
        CharacterType();

        InitStat();
    }

    public virtual void InitStat()
    {

        Stat[(int)eSTAT.eSTAT_HP] = 100;
        Stat[(int)eSTAT.eSTAT_MP] = 10;
        Stat[(int)eSTAT.eSTAT_ATK] = 10;
        Stat[(int)eSTAT.eSTAT_DEF] = 5;
        Stat[(int)eSTAT.eSTAT_SPEED] = 3;
        Stat[(int)eSTAT.eSTAT_RES] = 5;

        HpMax = Stat[(int)eSTAT.eSTAT_HP];
    }


   
    public void Move(Vector3 _Pos)
    {
        Vector3 direct = _Pos - transform.position;

        transform.position += direct.normalized * moveSpeed * Time.deltaTime;

        lookTarget = Quaternion.LookRotation(direct).normalized;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.1f);
    }

}
