using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;


public class Table_Reload : MonoBehaviour
{
    [MenuItem("Cs_Util/Table/CSV &F1", false, 1)]//여러 개 있을 때는 우선순위를 매겨서 나오게 해줌.
    static public void Parser_Table_CSV()//스태틱이어야만 인지를 함.
    {
        Shared.TableMgr = new Table_Mgr();
        Shared.TableMgr.Init();
        Shared.TableMgr.Save();
    }
}
