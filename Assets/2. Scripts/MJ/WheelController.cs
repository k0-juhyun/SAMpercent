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

    private void InitMoveInput()
    {
        xrLeftController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftStop);

        xrRightController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out rightAcceleration);

        currentAcceleration = acceleration * rightAcceleration * 2;

        //�ڵ��� z�� ȸ�� ������ ���� ���� ������ ������.
    }

    //�θ� ���� ���� �ʰ� �����.
    public void FixParent() => handle.SetParent(transform);
}