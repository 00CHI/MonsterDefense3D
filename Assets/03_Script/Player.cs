using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 direct;
    Quaternion lookTarget;

    bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycastHit, 100f))
            {
                originalPosition = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
                direct = originalPosition - transform.position;

                lookTarget = Quaternion.LookRotation(direct);
                move = true;
            }
        }

        MoveOnClick();
    }
    private void MoveOnClick()
    {
        if(move)
        {
            transform.position += direct.normalized * Time.deltaTime * 2f;
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);

            //ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���� �̵�
            move = (transform.position - originalPosition).magnitude > 0.05f;
        }
    }
}
