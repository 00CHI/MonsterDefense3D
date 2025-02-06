using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    public Dictionary<int, Character> DicCharacter =
        new Dictionary<int, Character>();

    public Character Player;

    int Key;

    private void Awake()
    {
        Shared.BattleMgr = this;
        
    }

    private void Start()
    {
        CreatePlayer();
        CreateMonster();
    }

    public void CreatePlayer()
    {
        UnityEngine.Object playerObj = Resources.Load("04_Prefab/Character/"+"Player");
        //���� 

        if (playerObj == null) 
        {
            return;
        }

        //Player
        GameObject pObj = GameObject.Instantiate(playerObj, Vector3.zero,
            Quaternion.identity) as GameObject;// as :��ü�� ����ȯ �����ִ� ���� ()�� ���� ����ȯ as�� ����ȯ�� �� ��쿡�� �ٲٵ������� 

        pObj.transform.SetParent(Shared.Stage.TRPLAYER);
        pObj.transform.localScale = new Vector3(1, 1, 1);
        pObj.transform.position = Shared.Stage.TRPLAYER.position;

        Player = pObj.AddComponent<Player>();

        if (Player == null)
        {
            return;
        }

        Player.Init();

        //DicCharacter.Add(Key, Player);

        Key++;
    }

    public void CreateMonster()
    {
        UnityEngine.Object monsterObj = Resources.Load("04_Prefab/Character/" + "Monster");

        if (monsterObj == null)
        {
            return;
        }

        //Monster
        GameObject mObj = GameObject.Instantiate(monsterObj, Vector3.zero,
           Quaternion.identity) as GameObject;

        mObj.transform.SetParent(Shared.Stage.TRMONSTER);
        mObj.transform.position = Shared.Stage.TRMONSTER.position;
        mObj.transform.localScale = new Vector3(1, 1, 1);

    }

}
