using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Transform TRPLAYER;
    public Transform TRMONSTER;

    public List<Transform> TRPATH;


    // Start is called before the first frame update
    void Awake()
    {
        Shared.Stage = this;
    }

}
