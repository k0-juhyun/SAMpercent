using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAccident : MonoBehaviour
{
    private int contactAccidentScore = 15;

    // ���� �ؼ� ����
    // ���巹�Ͽ� �浹�ϸ� ����
    private void OnCollisionEnter(Collision collision)
    {
        print("���巹�� �浹 ����");
        // ����
        ScoreManager.instance.Deduction(contactAccidentScore);
    }
}
