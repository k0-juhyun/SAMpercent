using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSuddenStop : MonoBehaviour
{
    private JHCarTest carTest;
    private WheelController wheelController;

    private int suddenStopScore = 10;

    private float breakLimitTime = 2;
    private float lightLimitTime = 3;

    // 브레이크를 누른적이 있는지 확인
    private bool isBreakPushed;

    // 돌발등이 켜졌을때
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        wheelController = other.GetComponent<WheelController>();

        if (wheelController.leftStop)
            isBreakPushed = true;
        
        // 2 초이내에 브레이크를 누르지못한 경우
        while (!wheelController.leftStop && breakLimitTime > 0 && !isBreakPushed)
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
        if (wheelController.leftStop)
        {
            while (!carTest.isHazardWarningLight && lightLimitTime > 0)
            {
                lightLimitTime -= Time.deltaTime;

                if (lightLimitTime <= 0)
                {
                    ScoreManager.instance.Deduction(suddenStopScore);
                    print("3초 이내에 비상깜빡이 키지않아서 감점: " + suddenStopScore);
                }
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 다시 출발 시 비상깜빡이를 끄지 않은 경우
        if (carTest.isHazardWarningLight 
            && other.gameObject.name == "CarTrqigger")
        {
            ScoreManager.instance.Deduction(suddenStopScore);
            print("출발 시 비상깜빡이 끄지않아서 감점: " + suddenStopScore);
        }
    }
}
