using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class WheelController : MonoBehaviour
{
    //wheelColider 4개를 가져온다.
    public WheelCollider[] wheelColliders = new WheelCollider[4];

    //가속 힘을 지정한다.
    public float acceleration = 500f, breakingForce = 300f;

    //현재 가속도, 현재 정지힘을 0으로 초기화한다.
    private float currentAcceleration = 0f, currentBreakForce = 0f;

    private void FixedUpdate()
    {
        //xr toolkit의 oculus 오른쪽 컨트롤러의 트리거 값을 받아온다 OVRInput 말고
    }
}