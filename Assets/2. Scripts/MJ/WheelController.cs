using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelController : MonoBehaviour
{
    //wheelColider 4개를 가져온다.
    public WheelCollider[] wheelColliders = new WheelCollider[4];

    //가속 힘을 지정한다.
    public float acceleration = 500f, breakingForce = 300f, maxTurnAngle = 45f;

    //현재 가속도, 현재 정지힘을 0으로 초기화한다.
    private float currentAcceleration = 0f, currentBreakForce = 0f, currentTurnAngle;

    public Transform handle;

    public void FixedUpdate()
    {
        InitMoveInput();
        InitWheelPropertys();
        Stop();
    }

    private void InitWheelPropertys()
    {
        for (int i = 0; i < 2; i++)
        {
            //앞 뒤 방향 속도 지정
            wheelColliders[i].motorTorque = currentAcceleration;
            //좌우 회전 각 방향 지정
            wheelColliders[i].steerAngle = currentTurnAngle;
        }

        //앞 뒤바퀴의 모든 토크를 currentbreakforece로 설정한다.
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.brakeTorque = currentBreakForce;
        }
    }

    private void Stop()
    {
        //VR 왼쪽 핸들의 Trigger를 눌렀을 때
        if (leftStop) currentBreakForce = breakingForce;
        else currentBreakForce = 0f;
    }

    public XRController xrLeftController;
    public XRController xrRightController;

    private bool leftStop;
    private float rightAcceleration;

    private void InitMoveInput()
    {
        xrLeftController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftStop);

        xrRightController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out rightAcceleration);

        currentAcceleration = acceleration * rightAcceleration * 2;

        //핸들의 z축 회전 각도에 따른 바퀴 각도를 돌린다.
    }

    //부모가 널이 되지 않게 만든다.
    public void FixParent() => handle.SetParent(transform);
}