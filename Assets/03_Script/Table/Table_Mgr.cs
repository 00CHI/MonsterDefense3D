using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Table_Mgr
{
    public Table_Character Character = new Table_Character();

    public void Init()
    {
#if UNITY_EDITOR
        Character.init_CSV("Monster3D", 1, 0);
#else
        Character.init_Binary("Character");
#endif
    }

    public void Save()
    {
        Character.Save_Binary("Character");

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}
