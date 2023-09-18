using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���̿��� �����ϰ�
// 4�� ���� ������ �Ŀ�
// ���ο��� �극��ũ �����鼭 ��������
public class HandleHill : MonoBehaviour
{
    private WheelController wheelController;

    // ���� �ð�
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
        // 4�� ���� �����ؾ��Ѵ�
        while (stopTime > 0 && wheelController.leftStop)
        {
            stopTime -= Time.deltaTime;

            if (stopTime <= 0)
            {
                print("4�� ����");
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