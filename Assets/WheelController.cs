using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class WheelController : MonoBehaviour
{
    //wheelColider 4���� �����´�.
    public WheelCollider[] wheelColliders = new WheelCollider[4];

    //���� ���� �����Ѵ�.
    public float acceleration = 500f, breakingForce = 300f;

    //���� ���ӵ�, ���� �������� 0���� �ʱ�ȭ�Ѵ�.
    private float currentAcceleration = 0f, currentBreakForce = 0f;

    private void FixedUpdate()
    {
        //xr toolkit�� oculus ������ ��Ʈ�ѷ��� Ʈ���� ���� �޾ƿ´� OVRInput ����
    }
}