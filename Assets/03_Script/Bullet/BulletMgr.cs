using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    Dictionary<int, Bullet> DicBulletMgr = 
        new Dictionary<int, Bullet>();

    //Queue<int> QueueBulletMgr = new Queue<int>();

    List<int> ListRemove = new List<int>();


    public int Key = -1;


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


        //레이어로 아군 적군 설정.
    }

    public void CreateArrow(Player _Player, Monster monster, int _Damage, float _Speed, string _Prefabs)
    {
        //씬을 변경하면 가비지콜렉터가 무조건 실행됨 < 메모리 풀 역할을 함.(참고)

        UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

        Bullet bullet = null;


        //생성
        GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
        Quaternion.identity) as GameObject;

        if (arrowObj == null)
        {
            return;
        }

        aObj.transform.localScale = new Vector3(1, 1, 1);


        aObj.transform.rotation = _Player.transform.rotation;
        aObj.transform.position = _Player.transform.position;

        bullet = aObj.GetComponent<StraightArrow>();

        StraightArrow b = (StraightArrow)bullet;

        b.Init(_Speed, _Damage);

        
    }
}

//
//DicBulletMgr.Add(Key, bullet);

//Debug.Log("Count: " + ListBulletMgr.Count);

//if(Key >= 10)
//{
//    DicBulletMgr.Remove(Key);
//    ListBulletMgr.Add(Key);
//    StartCoroutine(Shared.Player.SetFalse(aObj));


//    //DicBulletMgr.Remove(Key);

//    Debug.Log("Key: " + Key);
//}


//
//public void CreateArrow(Player _Player, int _Damage, float _Speed, string _Prefabs)
//{
//    //씬을 변경하면 가비지콜렉터가 무조건 실행됨 < 메모리 풀 역할을 함.(참고)

//    UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

//    Bullet bullet = null;

//    if (0 < ListRemove.Count)
//    {
//        Key = ListRemove[0];

//        bullet = DicBulletMgr[Key];

//        //불렛 셋팅//key값 필수
//        DicBulletMgr.Add(Key, bullet);

//        ListRemove.Remove(Key);

//    }
//    else
//    {
//        //생성
//        GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
//        Quaternion.identity) as GameObject;

//        if (arrowObj == null)
//        {
//            return;
//        }

//        aObj.transform.localScale = new Vector3(1, 1, 1);


//        aObj.transform.rotation = _Player.transform.rotation;
//        aObj.transform.position = _Player.transform.position;

//        bullet = aObj.GetComponent<StraightArrow>();

//        StraightArrow b = (StraightArrow)bullet;

//        b.Init(_Speed, _Damage);


//        RemoveBullet(Key);
//    }
//}

//public void RemoveBullet(int _Key)
//{
//    if (!DicBulletMgr.ContainsKey(_Key))
//    {
//        return;
//    }

//    DicBulletMgr[_Key].gameObject.SetActive(false);

//    ListRemove.Add(Key);
//}

