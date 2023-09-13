using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;

    //ȸ���� ���� �̺�Ʈ�� �����ϴ� ����Ʈ�� �����.
    public UnityEvent<float> HandleRotated;

    //���� ������ �����ϴ� ������ �����.
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
        //�ڵ��� ���� ������ ã�Ƽ� ���� ���� ������ �����Ѵ�.
        currentAngle = GetHandleAngle();
        print("�ڵ��� �����ߴ�.");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        //�ڵ��� ���� ������ ã�Ƽ� ���� ���� ������ �����Ѵ�.
        currentAngle = GetHandleAngle();
        print("�ڵ��� ������.");
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        //1. updatePhase�� Dynamic�̸鼭
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            //2. ���õ� ��ȣ�ۿ��� �ִٸ�
            if (isSelected)
            {
                //3. �ڵ��� ������.
                RotateHandle();
                print("�ڵ��� ������.");
            }
        }
    }

    //�ڵ��� ������.
    private void RotateHandle()
    {
        //1. ���� �� ������ ���Ѵ�.
        float totalHandleAngle = GetHandleAngle();
        //2. ���� ������ ���� ������ ���̸� ���Ѵ�.
        float angleDifference = currentAngle - totalHandleAngle;
        //3. �ڵ��� z�� ��������, ������ ��ŭ, ���� �������� �ε巴�� ������.
        handle.Rotate(transform.forward, -angleDifference, Space.World);
        ////4. ���� ������ �� ������ �����Ѵ�.
        currentAngle = totalHandleAngle;
        ////5. �ڵ� �̺�Ʈ�� ���� �� �ڵ��� ���� ���� ����Ʈ �̺�Ʈ�� �����Ѵ�.
        HandleRotated?.Invoke(angleDifference);
    }

    //�ڵ� ������ �����´�.
    private float GetHandleAngle()
    {
        //1. ���� �� ���� ������ �����.
        float totalAngle = 0f;
        //2. ��ȣ�ۿ� ���õ� IXRSelectInteractor�� �����´�.
        foreach (IXRSelectInteractor interactor in interactorsSelecting)
        {
            //3. ��ȣ�ۿ� ���õ� interactor�� ��ġ ���͸� �������� ������ �����Ѵ�.
            Vector3 interactorPos = interactor.transform.localPosition;
            //4. �� ������ ��ġ ���� ������ ȸ�� �ΰ���f
            totalAngle += SetHandleAngle(interactorPos) * GetRotationSensitivity();
        }
        //5.ȸ�� ������ �ε巴�� ȸ���ϵ��� ��ȯ�Ѵ�.
        return totalAngle;
    }

    //�� ���� ������ ������ ���Ѵ�(signedAngle) zȸ�� �� ����, ���� ����)
    private float SetHandleAngle(Vector3 direction)
    {
        float rotationAngle = Vector2.SignedAngle(transform.up, direction);
        return Mathf.SmoothDampAngle(handle.eulerAngles.z, rotationAngle, ref rotationVelocity, rotationTime);
    }

    //��� ȸ�� ������ �� �۰� ���
    private float GetRotationSensitivity() => 1.0f / interactorsSelecting.Count;
}