using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenStop : MonoBehaviour
{
    private ScoreManager scoreManager;

    private int suddenStopScore = 10;

    private bool isBreak;
    private bool isHazardWarningLight;

    private float breakLimitTime = 2;
    private float lightLimitTime = 3;

    private void Awake()
    {
        scoreManager = GetComponentInParent<ScoreManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isBreak = true;
            print("브레이크");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isHazardWarningLight = true;
            print("비상깜빡이");
        }
    }
    // 돌발등이 켜졌을때
    private void OnTriggerStay(Collider other)
    {
        // 2 초이내에 브레이크를 누르지못한 경우
        while (!isBreak && breakLimitTime > 0)
        {
            breakLimitTime -= Time.deltaTime;

            if (breakLimitTime <= 0)
            {
                scoreManager.Deduction(suddenStopScore);
                print("2초 이내에 브레이크 밟지 않아서 감점: " + suddenStopScore);
            }
            break;
        }

        // 정지 후 3초 이내에 비상깜빡이 키지 않은 경우
        while (!isHazardWarningLight && lightLimitTime > 0)
        {
            lightLimitTime -= Time.deltaTime;

            if (lightLimitTime <= 0)
            {
                scoreManager.Deduction(suddenStopScore);
                print("3초q 이내에 비상깜빡이 키지않아서 감점: " + suddenStopScore);
            }
            break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 다시 출발 시 비상깜빡이를 끄지 않은 경우
        if (isHazardWarningLight 
            && other.gameObject.name == "CarTrigger")
        {
            scoreManager.Deduction(suddenStopScore);
            print("출발 시 비상깜빡이 끄지않아서 감점: " + suddenStopScore);
        }
    }
}
