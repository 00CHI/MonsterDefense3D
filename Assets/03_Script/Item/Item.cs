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

    public eSTAT StatType;//� �����ΰ�
    public int StatValue;//�� ���ȿ� �߰����ִ� ��

    public void SetStat()
    {
        Random ran = new Random();

        int value = ran.Next(0, (int)eSTAT.eSTAT_END);
        StatType = (eSTAT)value;

        StatValue = ran.Next(10, 20);
    }
}

//1.��� ������ �������� ����ÿ�
//2.�����ۿ� �ɷ�ġ 1���̻� �ʿ�
//3.������ ������ ��(�Ϲ�), ����(���), ����(����)