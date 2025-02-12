using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    Dictionary<int, Bullet> DicBulletMgr = 
        new Dictionary<int, Bullet>();

    //Queue<int> QueueBulletMgr = new Queue<int>();

    
    int Key;

    //몬스터 찾아오기
    //몬스터 컴포넌트를 이용해서 찾기.

    //오브젝트 풀링
    //List에 오브젝트가 없으면 생성
    //List에 오브젝트가 있으면 끌어오기
    //Dic <> List 왔다갔다 or Dic의 키값을 재사용
    //오브젝트 끄고 Dic 에서 삭제 후 List에 불렛을 추가

    // Start is called before the first frame update
    void Awake()
    {
        Shared.BulletMgr = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CreateBullet(Shared.Player, Shared.Monster, 3f, "Arrow_01");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateArrow(5f, "Arrow_02");
        }

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

        //레이어로 아군 적군 설정.
    }

    void CreateArrow(float _Speed, string _Prefabs)
    {
        UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

        GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
        Quaternion.identity) as GameObject;

        if (arrowObj == null)
        {
            return;
        }

        aObj.transform.localScale = new Vector3(1, 1, 1);


        aObj.transform.rotation = Shared.Player.transform.rotation;
        aObj.transform.position = Shared.Player.transform.position;

        StraightArrow bullet = aObj.GetComponent<StraightArrow>();

        bullet.Init(_Speed);
    }

}
