using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �������� �ü� 20km�� ���� ���� ���
// ���� ���� ���� ������
// ���� ���� ��������
// ���� ������ �ִ� ����
public class AccelerationArea : MonoBehaviour
{
    [SerializeField]
    private float limitSpeed = 200;
    private float carSpeed;

    private int accelerationScore = 10;

    private bool underSpeed;

    private void OnTriggerStay(Collider other)
    {
        // �ڵ����� �ӵ�
        Rigidbody carRB = other.GetComponentInParent<Rigidbody>();
        carSpeed = carRB.velocity.magnitude;

        // ���� �������� �ڵ��� �ӵ��� ���� �ӵ����� �Ʒ����
        if(carSpeed <= limitSpeed)
        {
            print("�ü� 10km ����");
            underSpeed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���� �������� ������ �̹� ���� �ӵ����� �Ʒ����ٸ� ����
        if(other.gameObject.name == "CarTrigger" && underSpeed)
        {
            ScoreManager.instance.Deduction(accelerationScore);
            print("���� �������� �ӵ��� ������ ����: " + accelerationScore);
        }
    }
}
