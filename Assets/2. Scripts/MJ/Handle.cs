using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Enumeration;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform handleCenter;

    // 회전한 누적 값
    public float totalRotateAngle;

    // 돌아갈 때 회전해야하는 방향
    private int directionOfRotation = 0;

    private Vector3 grabbedHand;
    public float smoothTime = 1f;

    private readonly float kAdjust = 150f;
    private readonly float handleRotationSpeed = 300f;
    private readonly int leftRotation = 1;
    private readonly int rightRotation = -1;
    private float currentTime;
    public float initRotationTime = 2.5f;

    /*   //회전한 각도 이벤트를 저장하는 리스트를 만든다.
       public UnityEvent<float> HandleRotated;

       //현재 각도를 저장하는 변수를 만든다.
       private float currentAngle = 0f;

       public float rotationTime = 1f;
       private float rotationVelocity;*/

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        //내가 잡은 핸들 충돌 오브젝트위치를 가져온다.
        grabbedHand = handleCenter.localPosition.normalized;

        //원상복구 하는 도중 남은 각도를 원래값으로 되돌리자
        totalRotateAngle *= -directionOfRotation;
        print("핸들을 선택했다.");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (totalRotateAngle > 0) directionOfRotation = rightRotation;
        else directionOfRotation = leftRotation;

        //회전각을 절대 값으로 만든다.
        totalRotateAngle = Mathf.Abs(totalRotateAngle);
        print("핸들을 나갔다.");
    }

    private void SetInsideHandPosition()
    {
        //수직으로 세운다.
        handleCenter.localEulerAngles = Vector3.zero;
        handleCenter.position = hand.position;
        Vector3 localPos = handleCenter.localPosition;
        localPos.z = 0;
        localPos = localPos.normalized * 0.5f;
        handleCenter.localPosition = localPos;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        //fixedUpdate 단계로 실행한다.
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed)
        {
            //2. 선택된 상호작용이 있다면
            if (isSelected)
            {
                //3. 핸들을 돌린다.
                RotateHandle();
                //print("핸들을 돌린다.");
            }
            else
            {
                currentTime += Time.deltaTime;

                if (totalRotateAngle != 0 && currentTime > initRotationTime)
                {
                    handle.Rotate(0, 0, handleRotationSpeed * directionOfRotation * Time.deltaTime);
                    //회전각도 감소 시킨다.
                    totalRotateAngle -= handleRotationSpeed * Time.deltaTime;
                    if (totalRotateAngle <= 0)
                    {
                        totalRotateAngle = 0;
                        handle.localEulerAngles = new Vector3(25, 0, 0);
                        currentTime = 0f;
                    }
                }
            }
            SetInsideHandPosition();
            handleCenter.RotateAround(transform.position, transform.right, 25);
        }
    }

    private void RotateHandle()
    {
        Vector3 crossHandle = Vector3.Cross(grabbedHand, handleCenter.localPosition.normalized);

        float angle = Vector3.Angle(grabbedHand, handleCenter.localPosition.normalized) * crossHandle.normalized.z;

        totalRotateAngle += angle;

        //z축 기준으로 0도 부터 총 회전한 각도 각까지 Slerp로 부드럽게 회전한다.
        handle.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(25f, 0f, totalRotateAngle), smoothTime * kAdjust * Time.deltaTime);

        grabbedHand = handleCenter.localPosition.normalized;
    }

    /*    private void OnTriggerEnter(Collider other)
        {
            //부딪힌 레이어가 Handle일 때 local 위치를 기억한다.
            if (other.gameObject.layer == LayerMask.NameToLayer("Hand"))
            {
                GetComponent<Instance_ID>().rightHand.transform.localPosition = other.transform.position;
            }
        }*/
}