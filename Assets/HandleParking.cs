using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleParking : MonoBehaviour
{
    private JHCarTest carTest;
    private AudioSource audioSource;

    private float stopTime = 2;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 주차해서 사이드 브레이크 올리고
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        if (carTest == null)
            return;

        while (stopTime > 0 && carTest.isSideBreak)
        {
            stopTime -= Time.deltaTime;

            if (stopTime <= 0)
            {
                print("2초 지남");
            }
            break;
        }
    }

    // 주차 끝나고 나갈땐 사이드 브레이크 다시 내려야함
    private void OnTriggerExit(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        // 사이드 브레이크가 올라가있으면
        if (carTest.isSideBreak)
        {
            ScoreManager.instance.Deduction(5);
        }
        else
        {
            audioSource.enabled = true;
            HandleNavi.instance.currentContent = HandleNavi.CurrentContent.End;
        }
            
    }
}
