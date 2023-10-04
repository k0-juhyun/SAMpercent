using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSuddenStop : MonoBehaviour
{
    private JHCarTest carTest;
    private WheelController wheelController;
    private AudioSource audioSource;

    private int suddenStopScore = 10;

    private float breakLimitTime = 2;
    private float lightLimitTime = 3;

    public AudioClip[] Clips;

    // 브레이크를 누른적이 있는지 확인
    private bool isBreakPushed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 돌발 사운드 켜짐
        audioSource.enabled = true;
    }

    // 돌발등이 켜졌을때
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        wheelController = other.GetComponentInParent<WheelController>();

        if (wheelController == null)
            return;

        // wheelController.leftstop 으로 교체할 것
        if (wheelController.leftStop)
            isBreakPushed = true;

        // 2 초이내에 브레이크를 누르지못한 경우
        // wheelController.leftstop 으로 교체할것
        while (!wheelController.leftStop && breakLimitTime > 0 && !isBreakPushed)
        {
            breakLimitTime -= Time.deltaTime;

            if (breakLimitTime <= 0)
            {
                ScoreManager.instance.Deduction(suddenStopScore);
                audioSource.Stop();
                print("2초 이내에 브레이크 밟지 않아서 감점: " + suddenStopScore);
            }
            break;
        }

        // 정지 후 3초 이내에 비상깜빡이 키지 않은 경우
        //if (wheelController.leftStop)
        //{
        //    print("호출1");
        //    while (!carTest.isHazardWarningLight && lightLimitTime > 0)
        //    {
        //        print("호출2");
        //        lightLimitTime -= Time.deltaTime;

        //        if (lightLimitTime <= 0)
        //        {
        //            ScoreManager.instance.Deduction(suddenStopScore);
        //            print("3초 이내에 비상깜빡이 키지않아서 감점: " + suddenStopScore);
        //        }
        //        break;
        //    }
        //}
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
        else
        {
            audioSource.clip = Clips[0];
            audioSource.Play();
        }
    }
}