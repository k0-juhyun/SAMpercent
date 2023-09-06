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

    // 차로 준수 위반
    // 가드레일에 충돌하면 감점
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        // 감점
        scoreManager.Deduction(contactAccidentScore);
    }
}
