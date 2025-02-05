using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    Dictionary<int, Character> DicCharacter =
        new Dictionary<int, Character>();

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
        UnityEngine.Object monsterObj = Resources.Load("04_Prefab/Character/" + "Monster");
        //���� 

        if (playerObj == null) 
        {
            return;
        }
        if (monsterObj == null)
        {
            return;
        }

        //Player
        GameObject pObj = GameObject.Instantiate(playerObj, Vector3.zero,
            Quaternion.identity) as GameObject;// as :��ü�� ����ȯ �����ִ� ���� ()�� ���� ����ȯ as�� ����ȯ�� �� ��쿡�� �ٲٵ������� 

        pObj.transform.SetParent(Shared.Stage.TRPLAYER);
        pObj.transform.position = Shared.Stage.TRPLAYER.position;
        pObj.transform.localScale = new Vector3(1, 1, 1);

        Character character = pObj.GetComponent<Character>();

        //Monster
        GameObject mObj = GameObject.Instantiate(monsterObj, Vector3.zero,
           Quaternion.identity) as GameObject;

        mObj.transform.SetParent(Shared.Stage.TRMONSTER);
        mObj.transform.position = Shared.Stage.TRMONSTER.position;
        mObj.transform.localScale = new Vector3(1, 1, 1);

        if (character == null)
        {
            return;
        }

        character.Init();

        DicCharacter.Add(Key, character);

        Key++;
    }

    public void CreateMonster()
    {

    }

}
