using System;
using UnityEngine;

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
        StopPedal();
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

    private void StopPedal()
    {
        //VR 왼쪽 핸들의 Trigger를 눌렀을 때
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }
    }

    private void InitMoveInput()
    {
        //오른쪽 핸들의 Trigger를 눌렀을 때 앞으로 가게 한다.
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        //핸들을 잡았을 때 두 수평 값을 가져온다.
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
    }
}