using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Enumeration;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;
    [SerializeField] private Transform hand;
    [SerializeField] private Transform handleCenter;

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
    private float currentTime;
    public float initRotationTime = 2.5f;

    /*   //ȸ���� ���� �̺�Ʈ�� �����ϴ� ����Ʈ�� �����.
       public UnityEvent<float> HandleRotated;

       //���� ������ �����ϴ� ������ �����.
       private float currentAngle = 0f;

       public float rotationTime = 1f;
       private float rotationVelocity;*/

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        //���� ���� �ڵ� �浹 ������Ʈ��ġ�� �����´�.
        grabbedHand = handleCenter.localPosition.normalized;

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

        //fixedUpdate �ܰ�� �����Ѵ�.
        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Fixed)
        {
            //2. ���õ� ��ȣ�ۿ��� �ִٸ�
            if (isSelected)
            {
                //3. �ڵ��� ������.
                RotateHandle();
                //print("�ڵ��� ������.");
            }
            else
            {
                currentTime += Time.deltaTime;

                if (totalRotateAngle != 0 && currentTime > initRotationTime)
                {
                    handle.Rotate(0, 0, handleRotationSpeed * directionOfRotation * Time.deltaTime);
                    //ȸ������ ���� ��Ų��.
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

        //z�� �������� 0�� ���� �� ȸ���� ���� ������ Slerp�� �ε巴�� ȸ���Ѵ�.
        handle.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(25f, 0f, totalRotateAngle), smoothTime * kAdjust * Time.deltaTime);

        grabbedHand = handleCenter.localPosition.normalized;
    }

    /*    private void OnTriggerEnter(Collider other)
        {
            //�ε��� ���̾ Handle�� �� local ��ġ�� ����Ѵ�.
            if (other.gameObject.layer == LayerMask.NameToLayer("Hand"))
            {
                GetComponent<Instance_ID>().rightHand.transform.localPosition = other.transform.position;
            }
        }*/
}