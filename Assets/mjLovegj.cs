using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mjLovegj : MonoBehaviour
{
    public RawImage obj;
    public GameObject car;

    private Rigidbody rb;
    private float velo;
    private Quaternion originRot;

    private void Awake()
    {
        rb = car.GetComponent<Rigidbody>();

        // ������ ȸ������ ���� ����
        originRot = this.gameObject.transform.localRotation;
    }

    private void Update()
    {
        // car�� velocity ���� �����ͼ� z ȸ�������� ��ȯ
        float carVelocity = rb.velocity.magnitude; // Ȥ�� rb.velocity.z; �� ����Ͽ� z ���� �ӵ��� ����� �� �ֽ��ϴ�.
        float rotationAngle = Mathf.Clamp(carVelocity, 0, 40); // ���� 0�� 40 ���̷� ����

        // obj�� z �� ȸ���� ����
        Vector3 newRotation = originRot.eulerAngles;
        newRotation.z = rotationAngle;
        obj.transform.localRotation = Quaternion.Euler(newRotation);
    }
}