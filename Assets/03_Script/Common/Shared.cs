using System.Collections.Generic;

public static class Shared
{
    public static SceneMgr SceneMgr;
    public static AiBase AiBase;
    public static Stage Stage;
    public static BattleMgr BattleMgr;
    public static BulletMgr BulletMgr;
    public static Character Character;
    public static Player Player;
    public static Monster Monster;
    public static BulletArrow BulletArrow;

    public static Table_Mgr TableMgr;

    public static Table_Mgr InitTableMgr()
    {
        if(TableMgr == null)
        {
            TableMgr = new Table_Mgr();
            TableMgr.Init();
        }

        return TableMgr;
    }

    //public static BattleMgr BattleMgr;

}
