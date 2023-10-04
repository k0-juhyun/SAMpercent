using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelController : MonoBehaviour
{
    private Handle handleScript;

    //wheelColider 4개를 가져온다.
    public WheelCollider[] wheelColliders = new WheelCollider[4];

    //가속 힘을 지정한다.
    public float acceleration = 20f, breakingForce = 10f, maxTurnAngle = 25f, rotationRate = 60f;

    //현재 가속도, 현재 정지힘을 0으로 초기화한다.
    private float currentAcceleration = 0f, currentBreakForce = 0f, currentTurnAngle;

    public XRController xrLeftController, xrRightController;

    public bool leftStop;
    private float rightAcceleration;

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

        //오른쪽 컨트롤러의 X 버튼을 눌렀을 때
        xrRightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightButton);

        //rightButton이 true일 때 액셀 40, false일 때 엑셀 20 삼항 연산
        acceleration = rightButton ? 40f : 20f;
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

    //handle의 게임오브젝트의 부모를 handleFrame으로 만든다.
    public void FixParent() => handle.SetParent(handleFrame.transform);
}