using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;

    //회전한 각도 이벤트를 저장하는 리스트를 만든다.
    public UnityEvent<float> HandleRotated;

    //현재 각도를 저장하는 변수를 만든다.
    private float currentAngle = 0f;

    public float rotationTime = 1f;
    private float rotationVelocity;

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        //핸들을 돌린 각도를 찾아서 현재 각도 변수에 저장한다.
        currentAngle = GetHandleAngle();
        print("핸들을 선택했다.");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        //핸들을 돌린 각도를 찾아서 현재 각도 변수에 저장한다.
        currentAngle = GetHandleAngle();
        print("핸들을 나갔다.");
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        //1. updatePhase의 Dynamic이면서
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            //2. 선택된 상호작용이 있다면
            if (isSelected)
            {
                //3. 핸들을 돌린다.
                RotateHandle();
                print("핸들을 돌린다.");
            }
        }
    }

    //핸들을 돌린다.
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
    private float GetRotationSensitivity() => 1.0f / interactorsSelecting.Count;
}