using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public AiBase AI;

    float moveSpeed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        if (AI != null)
        {
            AI.Init(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
