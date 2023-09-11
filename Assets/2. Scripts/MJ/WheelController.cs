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
    private float rotationVelocity;
    public float rotationTime = 1f;

    public void FixedUpdate()
    {
        InitMoveInput();
        InitWheelPropertys();
        Stop();
        Accerate();
        RotateSteer();
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

    private void Stop()
    {
        //VR ���� �ڵ��� Trigger�� ������ ��
        if (Input.GetKey(KeyCode.Space) currentBreakForce = breakingForce;

    }

    private void Accerate() = currentBreakForce = 0f;

    private void InitMoveInput()
    {
        //������ �ڵ��� Trigger�� ������ �� ������ ���� �Ѵ�.
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        //�ڵ��� ����� �� �� ���� ���� �����´�.
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

    }

    private void RotateSteer()
    {
        //�ڵ� ������ z������ �ε巴�� ȸ����Ų��.
        float angle = Mathf.SmoothDampAngle(handle.eulerAngles.z, -currentTurnAngle * 6, ref rotationVelocity, rotationTime);

        //�ڵ��� ȸ������ �����Ѵ�.
        handle.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}