using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGuardRail : MonoBehaviour
{
    private int contactAccidentScore = 15;

    private JHCarTest carTest;
    // ���� �ؼ� ����
    // ���巹�Ͽ� �浹�ϸ� ����

    private void OnTriggerEnter(Collider other)
    {
        carTest = other.gameObject.GetComponentInParent<JHCarTest>();
        if (carTest != null)
        {
            if (carTest.isStartUp)
            {
                print("���巹�� �浹 ����");
                // ����
                ScoreManager.instance.Deduction(contactAccidentScore);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        carTest = collision.gameObject.GetComponentInParent<JHCarTest>();
        if(carTest != null)
        {
            if(carTest.isStartUp)
            {
                print("���巹�� �浹 ����");
                // ����
                ScoreManager.instance.Deduction(contactAccidentScore);
            }
        }
    }
}