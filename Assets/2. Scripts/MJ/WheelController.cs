using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

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
        if (leftStop) currentBreakForce = breakingForce;
        else currentBreakForce = 0f;
    }

    public XRController xrLeftController;
    public XRController xrRightController;

    private bool leftStop;
    private float rightAcceleration;
    private Vector2 vector2;

    private void InitMoveInput()
    {
        xrLeftController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftStop);

        xrRightController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out rightAcceleration);

        //xrLeftController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out vector2);
        //������ �ڵ��� Trigger�� ������ �� ������ ���� �Ѵ�.
        currentAcceleration = acceleration * rightAcceleration * 2;
        //�ڵ��� ����� �� �� ���� ���� �����´�.
        //currentTurnAngle = maxTurnAngle * vector2.x;
    }

    /*    public void RotateSteer()
        {
            //�ڵ� ������ z������ �ε巴�� ȸ����Ų��.
            float angle = Mathf.SmoothDampAngle(handle.eulerAngles.z, -currentTurnAngle * 6, ref rotationVelocity, rotationTime);

            //�ڵ��� ȸ������ �����Ѵ�.
            handle.localRotation = Quaternion.Euler(0f, 0f, angle);
        }*/

    //�θ� ���� ���� �ʰ� �����.
    public void FixParent() => handle.SetParent(transform);
}