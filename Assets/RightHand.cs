using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    public Transform rightHand;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        lineRenderer.SetPosition(0, ray.origin);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(ray, out hitInfo);
        if (isHit)
        {
            //��� �ε�����.
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            //����̴�. hand�� 100m ��
            lineRenderer.SetPosition(1, ray.origin + ray.direction * 100f);
        }

        if (Input.GetButton("Fire2"))
        {
            lineRenderer.enabled = true;
            if (isHit)
            {
                if (hitInfo.collider.CompareTag("Handle"))
                {
                    //�ڵ��� ��´�.
                    hitInfo.collider.transform.parent.Rotate(0, 0, 10 * Input.GetAxis("Mouse X"));
                }
            }
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            lineRenderer.enabled = false;
        }
    }
}