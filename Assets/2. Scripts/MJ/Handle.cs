using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Enumeration;

public class Handle : XRBaseInteractable
{
    [SerializeField] private Transform handle;
    [SerializeField] private Transform rightHandController;
    [SerializeField] private Transform leftHandController;
    [SerializeField] private GameObject leftHandModel;
    [SerializeField] private GameObject rightHandModel;
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

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        GrabHandle();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        AssignDirection();
    }

    private void GrabHandle()
    {
        //���� ���� �ڵ� �浹 ������Ʈ��ġ�� �����´�.
        grabbedHand = handleCenter.localPosition.normalized;

        GetComponent<Instance_ID>().rightHand.transform.position = rightHandController.position;

        GetComponent<Instance_ID>().leftHand.transform.position = leftHandController.position;

        //���󺹱� �ϴ� ���� ���� ������ ���������� �ǵ�����
        totalRotateAngle *= -directionOfRotation;
    }

    private void AssignDirection()
    {
        if (totalRotateAngle > 0) directionOfRotation = rightRotation;
        else directionOfRotation = leftRotation;

        //ȸ������ ���� ������ �����.
        totalRotateAngle = Mathf.Abs(totalRotateAngle);
    }

    private void SetGrabHandPosition()
    {
        //�޼����θ� ����� �� ���� ��Ʈ�ѷ� ��ġ�� �Ѵ�.

        handleCenter.localEulerAngles = Vector3.zero;

        //�����ո� ����� �� ������ ��ġ�� ���
        if (leftHandModel.activeSelf || rightHandModel.activeSelf) handleCenter.position = rightHandController.position;

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
                RotateHandle();
            }
            else
            {
                InitAngle();
            }
            SetGrabHandPosition();
            handleCenter.RotateAround(transform.position, transform.right, 25);
        }
    }

    private void InitAngle()
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

    private void RotateHandle()
    {
        Vector3 crossHandle = Vector3.Cross(grabbedHand, handleCenter.localPosition.normalized);

        float angle = Vector3.Angle(grabbedHand, handleCenter.localPosition.normalized) * crossHandle.normalized.z;

        totalRotateAngle += angle;

        //z�� �������� 0�� ���� �� ȸ���� ���� ������ Slerp�� �ε巴�� ȸ���Ѵ�.
        handle.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(25f, 0f, totalRotateAngle), smoothTime * kAdjust * Time.deltaTime);

        grabbedHand = handleCenter.localPosition.normalized;
    }
}