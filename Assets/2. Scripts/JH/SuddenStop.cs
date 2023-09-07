using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenStop : MonoBehaviour
{
    private JHCarTest carTest;

    private int suddenStopScore = 10;

    private float breakLimitTime = 2;
    private float lightLimitTime = 3;

    // 돌발등이 켜졌을때
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        // 2 초이내에 브레이크를 누르지못한 경우
        while (!carTest.isBreak && breakLimitTime > 0)
        {
            breakLimitTime -= Time.deltaTime;

            if (breakLimitTime <= 0)
            {
                ScoreManager.instance.Deduction(suddenStopScore);
                print("2초 이내에 브레이크 밟지 않아서 감점: " + suddenStopScore);
            }
            break;
        }

        // 정지 후 3초 이내에 비상깜빡이 키지 않은 경우
        while (!carTest.isHazardWarningLight && lightLimitTime > 0)
        {
            lightLimitTime -= Time.deltaTime;

            if (lightLimitTime <= 0)
            {
                ScoreManager.instance.Deduction(suddenStopScore);
                print("3초q 이내에 비상깜빡이 키지않아서 감점: " + suddenStopScore);
            }
            break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 다시 출발 시 비상깜빡이를 끄지 않은 경우
        if (carTest.isHazardWarningLight 
            && other.gameObject.name == "CarTrigger")
        {
            ScoreManager.instance.Deduction(suddenStopScore);
            print("출발 시 비상깜빡이 끄지않아서 감점: " + suddenStopScore);
        }
    }
}
