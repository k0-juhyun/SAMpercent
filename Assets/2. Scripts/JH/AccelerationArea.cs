using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 가속 구간에서 시속 20km를 넘지 못한 경우
// 가속 구간 진입 했을때
// 가속 구간 나왔을때
// 가속 구간에 있는 도중
public class AccelerationArea : MonoBehaviour
{
    [SerializeField]
    private float limitSpeed = 200;
    private float carSpeed;

    private int accelerationScore = 10;

    private bool underSpeed;

    private void OnTriggerStay(Collider other)
    {
        // 자동차의 속도
        Rigidbody carRB = other.GetComponentInParent<Rigidbody>();
        carSpeed = carRB.velocity.magnitude;

        // 가속 구간에서 자동차 속도가 제한 속도보다 아래라면
        if(carSpeed <= limitSpeed)
        {
            print("시속 10km 이하");
            underSpeed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 가속 구간에서 나갈때 이미 제한 속도보다 아래였다면 감점
        if(other.gameObject.name == "CarTrigger" && underSpeed)
        {
            ScoreManager.instance.Deduction(accelerationScore);
            print("가속 구간에서 속도가 느려서 감점: " + accelerationScore);
        }
    }
}
