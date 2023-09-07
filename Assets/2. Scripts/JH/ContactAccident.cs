using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAccident : MonoBehaviour
{
    private int contactAccidentScore = 15;

    // 차로 준수 위반
    // 가드레일에 충돌하면 감점
    private void OnCollisionEnter(Collision collision)
    {
        print("가드레일 충돌 감점");
        // 감점
        ScoreManager.instance.Deduction(contactAccidentScore);
    }
}
