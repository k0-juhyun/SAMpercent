using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelController : MonoBehaviour
{
    private Handle handleScript;

    //wheelColider 4���� �����´�.
    public WheelCollider[] wheelColliders = new WheelCollider[4];

    //���� ���� �����Ѵ�.
    public float acceleration = 500f, breakingForce = 300f, maxTurnAngle = 45f, rotationRate = 30f;

    //���� ���ӵ�, ���� �������� 0���� �ʱ�ȭ�Ѵ�.
    private float currentAcceleration = 0f, currentBreakForce = 0f, currentTurnAngle;

    public XRController xrLeftController, xrRightController;

    public bool leftStop;
    private float rightAcceleration;
    private Vector2 backAcceleration;

    private void Awake()
    {
        handleScript = GetComponentInChildren<Handle>();
    }

    public Transform handle;
    public GameObject handleFrame;

    public void FixedUpdate()
    {
        InitMoveInput();
        InitWheelPropertys();
        Stop();
        forwardMove();
        backMove();
        TurnDirection();
    }

    private void InitMoveInput()
    {
        xrLeftController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftStop);

        xrRightController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out rightAcceleration);
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

    private void TurnDirection() => currentTurnAngle = maxTurnAngle * -handleScript.totalRotateAngle / rotationRate;

    private void forwardMove()
    {
        if (PlayerInfo.instance.playerHandsObj.rightHand_Obj != null)
        {
            if (GearBox.instance.gearType == Enumeration.GearEventType.eDrive && PlayerInfo.instance.playerHandsObj.rightHand_Obj.gameObject.name == handle.name)
            {
                currentAcceleration = acceleration * rightAcceleration * 2;
            }
        }

    }

    private void backMove()
    {
        if (PlayerInfo.instance.playerHandsObj.rightHand_Obj != null)
        {
            if (GearBox.instance.gearType == Enumeration.GearEventType.eReverse && PlayerInfo.instance.playerHandsObj.rightHand_Obj.gameObject.name == handle.name)
            {
                currentAcceleration = acceleration * -rightAcceleration * 2;
            }
        }
    }

    //handle�� ���ӿ�����Ʈ�� �θ� handleFrame���� �����.
    public void FixParent() => handle.SetParent(handleFrame.transform);
}