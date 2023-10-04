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

        // 현재의 회전값을 먼저 저장
        originRot = this.gameObject.transform.localRotation;
    }

    private void Update()
    {
        // car의 velocity 값을 가져와서 z 회전값으로 변환
        float carVelocity = rb.velocity.magnitude; // 혹은 rb.velocity.z; 를 사용하여 z 방향 속도를 사용할 수 있습니다.
        float rotationAngle = Mathf.Clamp(carVelocity, 0, 40); // 값을 0과 40 사이로 제한

        // obj의 z 축 회전을 변경
        Vector3 newRotation = originRot.eulerAngles;
        newRotation.z = rotationAngle;
        obj.transform.localRotation = Quaternion.Euler(newRotation);
    }
}