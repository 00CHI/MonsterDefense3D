using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using Unity.VisualScripting; //어떤 규칙에 의해서 정보가 섞이도록 하기위함.(해킹방지용)

public class Table_Base
{
    string GetTablePath()
    {
        //전처리기 #if
#if UNITY_EDITOR
        return Application.dataPath;

        return Application.persistentDataPath + "/Assets";
#else
     
#endif //전처리기 #end if == 여기까지만 실행
    }

    //<T> 제너릭 전부 같은 자료형을 사용하겠다는 의미.
    protected void Load_Binary<T>(string _Name, ref T _obj)
    {
        var b = new BinaryFormatter();
        b.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

        TextAsset asset = Resources.Load("Table_" + _Name) as TextAsset;
        Stream stream = new MemoryStream(asset.bytes);

        _obj = (T)b.Deserialize(stream);

        stream.Close();
    }
    
    protected void Save_Binary(string _Name, object _obj)
    {
        string path = GetTablePath() + "/Table/Resources/" + "Table_" + _Name + ".txt";

        var b = new BinaryFormatter();
        Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
        b.Serialize(stream, _obj);
        stream.Close();

    }

    protected CSVReader GetCsvReader(string _Name)
    {
        string ext = ".csv";

        FileStream file = new FileStream("./Document/" + _Name + ext, FileMode.Open,
            FileAccess.Read, FileShare.ReadWrite);
        StreamReader stream = new StreamReader(file, System.Text.Encoding.UTF8);
        CSVReader reader = new CSVReader();
        reader.parse(stream.ReadToEnd(), false, 1);
        stream.Close();

        return reader;
    }
}

