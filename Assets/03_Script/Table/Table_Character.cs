using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static Table_Character;

public class Table_Character : Table_Base
{

    [Serializable]//데이터를 암호화하는 역할

    public class Info //Info == 어제 만들었던 테이블 
    {
        public int Id;
        public byte Type;
        public byte JobType;
        public int Hp;
        public int Atk;
        public int Def;
        public float Speed;
        public string Name;
        public string Dec;
        public string Icon;
        public int SkillId;

    }

    public Dictionary<int, Info> Dictionary = new Dictionary<int, Info>();

    public Info Get(int _Id)
    {
        if (Dictionary.ContainsKey(_Id))
            return Dictionary[_Id];

        return null;

    }

    public void InIt_Binary(string _Name)
    {
        Load_Binary<Dictionary<int, Info>>(_Name, ref Dictionary);//제너릭화 : 안에 있는 값이 다 다르지만 공통으로 사용되도록함.

    }

    public void Save_Binary(string _Name)
    {
        Save_Binary(_Name, Dictionary);
    }

    public void init_CSV(string _Name, int _StartRow, int _StartCol)
    {
        CSVReader reader = GetCsvReader(_Name);

        for (int row = _StartRow; row < reader.row; ++row)
        {
            Info info = new Info();

            if (Read(reader, info, row, _StartCol) == false)
                break;

            Dictionary.Add(info.Id, info);
        }
    }


    protected bool Read(CSVReader _Reader, Info _Info, int _Row, int _StartCol)
    {
        if (_Reader.reset_row(_Row, _StartCol) == false)
            return false;

        _Reader.get(_Row, ref _Info.Id);
        _Reader.get(_Row, ref _Info.Type);
        _Reader.get(_Row, ref _Info.JobType);
        _Reader.get(_Row, ref _Info.Hp);
        _Reader.get(_Row, ref _Info.Atk);
        _Reader.get(_Row, ref _Info.Def);
        _Reader.get(_Row, ref _Info.Speed);
        _Reader.get(_Row, ref _Info.Name);
        _Reader.get(_Row, ref _Info.Dec);
        _Reader.get(_Row, ref _Info.Icon);
        _Reader.get(_Row, ref _Info.SkillId);

        return true;
    }


}


