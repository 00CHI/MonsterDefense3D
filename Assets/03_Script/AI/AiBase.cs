using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBase : MonoBehaviour
{
    protected Character Character;

    public int TargetIndex = 0;

    protected eAI AIState = eAI.eAI_NONE;

    // Start is called before the first frame update
    void Start()
    {
        AIState = eAI.eAI_CREATE;
    }

    public void Init(Character _Character)
    {
        Character = _Character;

        TargetIndex = 0;
    }

    public void State()
    {
        switch(AIState)
        {
            case eAI.eAI_CREATE:
                Create();
                break;
            case eAI.eAI_SEARCH:
                Search();
                break;
            case eAI.eAI_MOVE:
                Move();
                break;
            case eAI.eAI_RESET:
                ReSet();
                break;
        }
    }

    protected virtual void Create()
    {
        AIState = eAI.eAI_SEARCH;
    }
    protected virtual void Search()
    {
        AIState = eAI.eAI_MOVE;

    }
    protected virtual void Move()
    {
        AIState = eAI.eAI_SEARCH;

    }
    protected virtual void ReSet()
    {
        AIState = eAI.eAI_SEARCH;
    }
}
