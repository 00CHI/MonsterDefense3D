using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    Dictionary<int, Bullet> DicBulletMgr = 
        new Dictionary<int, Bullet>();
    int Key;

    float FireSpeed = 3f;


    // Start is called before the first frame update
    void Awake()
    {
        Shared.BulletMgr = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            CreateArrow("Arrow_02");
            //CreateBullet(Shared.BattleMgr.Player.transform.position, Shared.Monster.transform.position, 3f , "Arrow_01");
        }
    }

    public void CreateBullet(Vector3 _Pos, Vector3 _TargetPos, float _Speed, string _Prefabs)
    {

        UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

        if (arrowObj == null)
        {
            return;
        }

        GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
            Quaternion.identity) as GameObject;

        BulletArrow bullet = aObj.GetComponent<BulletArrow>();

        //aObj.transform.SetParent();

        aObj.transform.position = _Pos;

        if (bullet == null)
        {
            return;
        }

        bullet.Init(_TargetPos, _Speed);

        DicBulletMgr.Add(Key, bullet);

        Key++;

        //레이어로 아군 적군 설정.
    }

    void CreateArrow(string _Prefabs)
    {
        UnityEngine.Object arrowObj = Resources.Load("04_Prefab/Bullet/" + _Prefabs);

        GameObject aObj = GameObject.Instantiate(arrowObj, Vector3.zero,
        Quaternion.identity) as GameObject;

        if (arrowObj == null)
        {
            return;
        }

        aObj.transform.localScale = new Vector3(1, 1, 1);

        Quaternion playerRotation = Shared.Player.transform.rotation;
        Vector3 playerPosition = Shared.Player.transform.position;

        Quaternion playerRotationZ = Quaternion.LookRotation(Shared.Player.transform.position);

        aObj.transform.rotation = Quaternion.Euler(playerRotation.x + 90, playerRotation.y, playerRotation.z);
        aObj.transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
    }

}
