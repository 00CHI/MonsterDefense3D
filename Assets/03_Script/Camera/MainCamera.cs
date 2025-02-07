using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
   public GameObject target;

    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float offsetZ = 0.0f;

    public float cameraSpeed = 5f;

    Vector3 targetPos;

    //Vector3 offset;

    private void Awake()
    {
        offsetX = 0f;
        offsetY = 8f;
        offsetZ = -13f;

        StartCoroutine(FindPlayer());


           
        //offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetPos = new Vector3(
            target.transform.position.x + offsetX,
            target.transform.position.y + offsetY,
            target.transform.position.z + offsetZ
            );

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * cameraSpeed);
        }
            
        //transform.position = target.transform.position + offset;

    }

    IEnumerator FindPlayer()
    {
        while (target == null)
        {
            target = GameObject.FindWithTag("Player");
            yield return new WaitForSeconds(0.5f);

            if (target != null)
            {
                break;
            }
        }
    }



}
