using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    GameObject Target;

    public float offsetX = 0f;
    public float offsetY = 5f;
    public float offsetZ = -7f;

    public float angleX = 30f;
    public float angleY = 0f;
    public float angleZ = 0f;

    public float CameraSpeed = 10f;

    Vector3 TargetPos;
     void Awake()
    {
        //Target
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //TargetPos = new Vector3 (
        //    Target.transform.position.x + offsetX,
        //    Target.transform.position.y + offsetY,
        //    Target.transform.position.z + offsetZ
        //    );

        //transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
