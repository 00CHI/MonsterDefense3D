using System;

public class ItemBase
{
    public eITEMTYPE ItemType;
}
public class Item : ItemBase
{
    public int ItemCount;
}
public class ItemEquip : ItemBase
{
    public eITEMEQUIP EquipType;
    public bool Equip;

    public eSTAT StatType;//어떤 스탯인가
    public int StatValue;//그 스탯에 추가해주는 값

    public void SetStat()
    {
        Random ran = new Random();

        int value = ran.Next(0, (int)eSTAT.eSTAT_END);
        StatType = (eSTAT)value;

        StatValue = ran.Next(10, 20);
    }
}

//1.상속 구조로 아이템을 만드시오
//2.아이템에 능력치 1개이상 필요
//3.아이템 종류는 돈(일반), 포션(사용), 무기(장착)