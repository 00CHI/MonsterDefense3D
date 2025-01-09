using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public partial class SceneMgr : MonoBehaviour
{

    [NonReorderable]
    Dictionary<string,SpriteAtlas> DicSpriteAtlas = new Dictionary<string, SpriteAtlas> ();

    public Image atlas;
    public string spriteName;
    
    //public Sprite atlasSprite;
    //public int atlasNumber;

    private void Update()
    {
        atlas = GetComponent<Image>();
        atlas.sprite = GetSpriteAtlas("Number_UI01", $"{spriteName}");
    }

    public Sprite GetSpriteAtlas(string _Atlas, string _Name)
    {
        if(DicSpriteAtlas.ContainsKey(_Atlas))
        {
            return DicSpriteAtlas[_Atlas].GetSprite(_Name);           
        }

        UnityEngine.Object obj = null;

        obj = Resources.Load("Atlas/" + _Atlas);

        if (obj == null)
        {
            return null;
        }

        SpriteAtlas sa = obj as SpriteAtlas;

        if (sa != null)
        {
            DicSpriteAtlas.Add(_Atlas, sa);
            return sa.GetSprite(_Name);
        }

        return null;
    }
}
