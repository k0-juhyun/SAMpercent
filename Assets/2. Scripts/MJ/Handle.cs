using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform insideHandModel;

    // ȸ���� ���� ��
    public float totalRotateAngle;

    // ���ư� �� ȸ���ؾ��ϴ� ����
    private int directionOfRotation = 0;

    private Vector3 grabbedHand;
    public float smoothTime = 1f;

    private readonly float kAdjust = 150f;
    private readonly float handleRotationSpeed = 300f;
    private readonly int leftRotation = 1;
    private readonly int rightRotation = -1;

    /*   //ȸ���� ���� �̺�Ʈ�� �����ϴ� ����Ʈ�� �����.
       public UnityEvent<float> HandleRotated;

       //���� ������ �����ϴ� ������ �����.
       private float currentAngle = 0f;

       public float rotationTime = 1f;
       private float rotationVelocity;*/

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        grabbedHand = insideHandModel.localPosition.normalized;
        //���󺹱� �ϴ� ���� ���� ������ ���������� �ǵ�����
        totalRotateAngle *= -directionOfRotation;
        print("�ڵ��� �����ߴ�.");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (totalRotateAngle > 0) directionOfRotation = rightRotation;
        else directionOfRotation = leftRotation;

        //ȸ������ ���� ������ �����.
        totalRotateAngle = Mathf.Abs(totalRotateAngle);
        print("�ڵ��� ������.");
    }

    private void SetInsideHandPosition()
    {
        //�������� �����.
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

        //fixedUpdate �ܰ�� �����Ѵ�.
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed)
        {
            //2. ���õ� ��ȣ�ۿ��� �ִٸ�
            if (isSelected)
            {
                //3. �ڵ��� ������.
                RotateHandle();
                print("�ڵ��� ������.");
            }
            else
            {
                if (totalRotateAngle != 0)
                {
                    handle.Rotate(0, 0, handleRotationSpeed * directionOfRotation * Time.deltaTime);
                    //ȸ������ ���� ��Ų��.
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

        //z�� �������� 0�� ���� �� ȸ���� ���� ������ Slerp�� �ε巴�� ȸ���Ѵ�.
        handle.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0f, 0f, totalRotateAngle), smoothTime * kAdjust * Time.deltaTime);

        grabbedHand = insideHandModel.localPosition.normalized;
    }

    /*    //�ڵ��� ������.
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
        private float GetRotationSensitivity() => 1.0f / interactorsSelecting.Count;*/
}