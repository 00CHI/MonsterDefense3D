using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : Character
{
    //Vector
    Vector3 originalPosition;
    Vector3 direct;
    
    //Quaternion
    Quaternion lookTarget;

    //Components
    Animator anim;

    //bool
    bool move = false;

    //float
    float moveSpeed = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        Shared.Player = this;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycastHit, 100f))
            {
                originalPosition = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
                direct = originalPosition - transform.position;

                lookTarget = Quaternion.LookRotation(direct);
                move = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
             Shared.BulletMgr.CreateArrow(this, Stat[(int)eSTAT.eSTAT_ATK], 5f, "Arrow_02");
        }

        

        MoveOnClick();
    }
    private void MoveOnClick()
    {
        if(move)
        {
            transform.position += direct.normalized * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);

            //ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���� �̵�
            move = (transform.position - originalPosition).magnitude > 0.05f;

            if((transform.position - originalPosition).magnitude <= 0.05f)
            {
                move = false;
            }
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

    }
    public override void CharacterType()
    {
        Type = eCHARACTER.eCHARACTER_PLAYER;
    }

    public override void Init()
    {
        base.Init();
    }

    public override void InitStat()
    {
        Stat[(int)eSTAT.eSTAT_HP] = 500;
        Stat[(int)eSTAT.eSTAT_MP] = 100;
        Stat[(int)eSTAT.eSTAT_ATK] = 25;
        Stat[(int)eSTAT.eSTAT_DEF] = 20;
        Stat[(int)eSTAT.eSTAT_SPEED] = 4;
        Stat[(int)eSTAT.eSTAT_RES] = 5;
    }

    public void Attack(Monster _Monster)
    {
        _Monster.InitStat();

        _Monster.Stat[(int)eSTAT.eSTAT_HP] -= Stat[(int)eSTAT.eSTAT_ATK];

        Debug.Log(_Monster.Stat[(int)eSTAT.eSTAT_HP]+ "���� HP��" + Stat[(int)eSTAT.eSTAT_ATK] + "��ŭ �������ϴ�.");
    }
}
