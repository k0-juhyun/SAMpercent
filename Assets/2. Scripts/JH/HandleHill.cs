using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���̿��� �����ϰ�
// 4�� ���� ������ �Ŀ�
// ���ο��� �극��ũ �����鼭 ��������
public class HandleHill : MonoBehaviour
{
    private JHCarTest carTest;
    private WheelController wheelController;
    private AudioSource audioSource;

    // ���� �ð�
    private float stopTime = 5;

    private int hillScore = 5;

    private bool check;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponent<JHCarTest>();
        if (carTest == null)
            return;

        //wheelController = other.GetComponentInParent<WheelController>();
        //if (wheelController == null)
        //    return;

        // wheelController.leftstop
        // 4�� ���� �����ؾ��Ѵ�
        while (stopTime > 0 && wheelController.leftStop)
        {
            stopTime -= Time.deltaTime;

            if (stopTime <= 0)
            {
                print("4�� ����");
                check = true;
                audioSource.enabled = true;
            }
            break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //wheelController = other.GetComponentInParent<WheelController>();
        //if (wheelController == null)
        //    return;

        carTest = other.GetComponent<JHCarTest>();
        if (carTest == null)
            return;

        // 4�� �̻� ���� ���Ѱ��
        if (false == check)
        {
            ScoreManager.instance.Deduction(hillScore);
            print("��� ����");
        }
        HandleNavi.instance.HandleNextContent();
        HandleNavi.instance.currentContent = HandleNavi.CurrentContent.TurnLeft;
    }
}