using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAccident : MonoBehaviour
{
    private ScoreManager scoreManager;

    private int contactAccidentScore = 15;

    private void Awake()
    {
        scoreManager = GetComponentInParent<ScoreManager>();   
    }

    // ���� �ؼ� ����
    // ���巹�Ͽ� �浹�ϸ� ����
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        // ����
        scoreManager.Deduction(contactAccidentScore);
    }
}
