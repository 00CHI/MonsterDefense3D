using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    Dictionary<int, Bullet> DicBulletMgr = 
        new Dictionary<int, Bullet>();

    //Queue<int> QueueBulletMgr = new Queue<int>();

    List<GameObject> ListBulletMgr = new List<GameObject>();


    int Key;

    //���� ã�ƿ���
    //���� ������Ʈ�� �̿��ؼ� ã��.

    //������Ʈ Ǯ��
    //List�� ������Ʈ�� ������ ����
    //List�� ������Ʈ�� ������ �������
    //Dic <> List �Դٰ��� or Dic�� Ű���� ����
    //������Ʈ ���� Dic ���� ���� �� List�� �ҷ��� �߰�

    // Start is called before the first frame update
    void Awake()
    {
        Shared.BulletMgr = this;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    CreateBullet(Shared.Player, Shared.Monster, 3f, "Arrow_01");
        //}

        //    if (Input.GetKeyDown(KeyCode.B))
        //    {
        //        CreateArrow(5f, "Arrow_02");
        //    }

        //}
    }
        public void CreateBullet(Player _Player, Monster _Monster, float _Speed, string _Prefabs)
    {

            UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

            if (arrowObj == null)
            {
                return;
            }

            GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
                Quaternion.identity) as GameObject;

            BulletArrow bullet = aObj.GetComponent<BulletArrow>();

            aObj.transform.position = _Player.transform.position;

            if (bullet == null)
            {
                return;
            }

            bullet.Init(_Monster.transform.position, _Speed);

            DicBulletMgr.Add(Key, bullet);

            Key++;
        Debug.Log(Key);

        //���̾�� �Ʊ� ���� ����.
    }

    public void CreateArrow(Player _Player,int _Damage, float _Speed, string _Prefabs)
    {
        UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

        GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
        Quaternion.identity) as GameObject;

        if (arrowObj == null)
        {
            return;
        }

        aObj.transform.localScale = new Vector3(1, 1, 1);


        aObj.transform.rotation = _Player.transform.rotation;
        aObj.transform.position = _Player.transform.position;

        StraightArrow bullet = aObj.GetComponent<StraightArrow>();

        bullet.Init(_Speed, _Damage);
    }

}
