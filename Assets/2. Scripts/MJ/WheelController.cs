using System;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    //wheelColider 4���� �����´�.
    public WheelCollider[] wheelColliders = new WheelCollider[4];

    //���� ���� �����Ѵ�.
    public float acceleration = 500f, breakingForce = 300f, maxTurnAngle = 45f;

    //���� ���ӵ�, ���� �������� 0���� �ʱ�ȭ�Ѵ�.
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
            //�� �� ���� �ӵ� ����
            wheelColliders[i].motorTorque = currentAcceleration;
            //�¿� ȸ�� �� ���� ����
            wheelColliders[i].steerAngle = currentTurnAngle;
        }

        //�� �ڹ����� ��� ��ũ�� currentbreakforece�� �����Ѵ�.
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.brakeTorque = currentBreakForce;
        }
    }

    private void StopPedal()
    {
        //VR ���� �ڵ��� Trigger�� ������ ��
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
        //������ �ڵ��� Trigger�� ������ �� ������ ���� �Ѵ�.
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        //�ڵ��� ����� �� �� ���� ���� �����´�.
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
    }
}