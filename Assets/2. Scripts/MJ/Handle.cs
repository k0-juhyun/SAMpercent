using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform insideHandModel;

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

    /*   //회전한 각도 이벤트를 저장하는 리스트를 만든다.
       public UnityEvent<float> HandleRotated;

       //현재 각도를 저장하는 변수를 만든다.
       private float currentAngle = 0f;

       public float rotationTime = 1f;
       private float rotationVelocity;*/

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        grabbedHand = insideHandModel.localPosition.normalized;
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
        insideHandModel.localEulerAngles = Vector3.zero;
        insideHandModel.position = hand.position;
        Vector3 localPos = insideHandModel.localPosition;
        localPos.z = 0;
        localPos = localPos.normalized * 0.5f;
        insideHandModel.localPosition = localPos;
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
                print("핸들을 돌린다.");
            }
            else
            {
                if (totalRotateAngle != 0)
                {
                    handle.Rotate(0, 0, handleRotationSpeed * directionOfRotation * Time.deltaTime);
                    //회전각도 감소 시킨다.
                    totalRotateAngle -= handleRotationSpeed * Time.deltaTime;
                    if (totalRotateAngle <= 0)
                    {
                        totalRotateAngle = 0;
                        handle.localEulerAngles = new Vector3(25, 0, 0);
                    }
                }
            }
            SetInsideHandPosition();
            insideHandModel.RotateAround(transform.position, transform.right, 25);
        }
    }

    private void RotateHandle()
    {
        Vector3 crossHandle = Vector3.Cross(grabbedHand, insideHandModel.localPosition.normalized);

        float angle = Vector3.Angle(grabbedHand, insideHandModel.localPosition.normalized) * crossHandle.normalized.z;

        totalRotateAngle += angle;

        //z축 기준으로 0도 부터 총 회전한 각도 각까지 Slerp로 부드럽게 회전한다.
        handle.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 0f, totalRotateAngle), smoothTime * kAdjust * Time.deltaTime);

        grabbedHand = insideHandModel.localPosition.normalized;
    }

    /*    //핸들을 돌린다.
        private void RotateHandle()
        {
            //1. 돌린 총 각도를 구한다.
            float totalHandleAngle = GetHandleAngle();
            //2. 현재 각도와 이전 각도의 차이를 구한다.
            float angleDifference = currentAngle - totalHandleAngle;
            //3. 핸들을 z축 방향으로, 간격차 만큼, 월드 방향으로 부드럽게 돌린다.
            handle.Rotate(transform.forward, -angleDifference, Space.World);
            ////4. 현재 각도를 총 각도로 저장한다.
            currentAngle = totalHandleAngle;
            ////5. 핸들 이벤트가 있을 때 핸들을 돌린 값을 리스트 이벤트에 저장한다.
            HandleRotated?.Invoke(angleDifference);
        }

        //핸들 각도를 가져온다.
        private float GetHandleAngle()
        {
            //1. 현재 총 각도 변수를 만든다.
            float totalAngle = 0f;
            //2. 상호작용 선택된 IXRSelectInteractor를 가져온다.
            foreach (IXRSelectInteractor interactor in interactorsSelecting)
            {
                //3. 상호작용 선택된 interactor의 위치 벡터를 가져오고 변수에 저장한다.
                Vector3 interactorPos = interactor.transform.localPosition;
                //4. 총 각도에 위치 벡터 각도와 회전 민감도f
                totalAngle += SetHandleAngle(interactorPos) * GetRotationSensitivity();
            }
            //5.회전 각도를 부드럽게 회전하도록 반환한다.
            return totalAngle;
        }

        //두 벡터 사이의 각도를 구한다(signedAngle) z회전 축 벡터, 비교할 벡터)
        private float SetHandleAngle(Vector3 direction)
        {
            float rotationAngle = Vector2.SignedAngle(transform.up, direction);
            return Mathf.SmoothDampAngle(handle.eulerAngles.z, rotationAngle, ref rotationVelocity, rotationTime);
        }

        //양손 회전 감도를 더 작게 사용
        private float GetRotationSensitivity() => 1.0f / interactorsSelecting.Count;*/
}