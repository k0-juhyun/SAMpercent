using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 정지선 사이에서 정차하고
// 4초 동안 정짛나 후에
// 경사로에서 브레이크 밟으면서 내려가기
public class HandleHill : MonoBehaviour
{
    private WheelController wheelController;

    // 정지 시간
    private float stopTime = 4;

    private int hillScore = 5;

    private bool check;

    private void OnTriggerStay(Collider other)
    {
        //carTest = other.GetComponentInParent<JHCarTest>();
        //if (carTest == null)
        //    return;

        wheelController = other.GetComponentInParent<WheelController>();
        if (wheelController == null)
            return;

        // wheelController.leftstop
        // 4초 동안 정지해야한다
        while (stopTime > 0 && wheelController.leftStop)
        {
            stopTime -= Time.deltaTime;

            if (stopTime <= 0)
            {
                print("4초 지남");
                check = true;
                SoundManager.Instance.PlaySFX(1);
            }
            break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wheelController = other.GetComponentInParent<WheelController>();
        if (wheelController == null)
            return;

        if (false == check)
            ScoreManager.instance.Deduction(hillScore);
    }
}