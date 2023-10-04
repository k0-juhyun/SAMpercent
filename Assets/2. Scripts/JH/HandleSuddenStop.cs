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

    // �극��ũ�� �������� �ִ��� Ȯ��
    private bool isBreakPushed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���� ����
        audioSource.enabled = true;
    }

    // ���ߵ��� ��������
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        wheelController = other.GetComponentInParent<WheelController>();

        if (wheelController == null)
            return;

        // wheelController.leftstop ���� ��ü�� ��
        if (wheelController.leftStop)
            isBreakPushed = true;

        // 2 ���̳��� �극��ũ�� ���������� ���
        // wheelController.leftstop ���� ��ü�Ұ�
        while (!wheelController.leftStop && breakLimitTime > 0 && !isBreakPushed)
        {
            breakLimitTime -= Time.deltaTime;

            if (breakLimitTime <= 0)
            {
                ScoreManager.instance.Deduction(suddenStopScore);
                audioSource.Stop();
                print("2�� �̳��� �극��ũ ���� �ʾƼ� ����: " + suddenStopScore);
            }
            break;
        }

        // ���� �� 3�� �̳��� �������� Ű�� ���� ���
        //if (wheelController.leftStop)
        //{
        //    print("ȣ��1");
        //    while (!carTest.isHazardWarningLight && lightLimitTime > 0)
        //    {
        //        print("ȣ��2");
        //        lightLimitTime -= Time.deltaTime;

        //        if (lightLimitTime <= 0)
        //        {
        //            ScoreManager.instance.Deduction(suddenStopScore);
        //            print("3�� �̳��� �������� Ű���ʾƼ� ����: " + suddenStopScore);
        //        }
        //        break;
        //    }
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        // �ٽ� ��� �� �������̸� ���� ���� ���
        if (carTest.isHazardWarningLight
            && other.gameObject.name == "CarTrqigger")
        {
            ScoreManager.instance.Deduction(suddenStopScore);
            print("��� �� �������� �����ʾƼ� ����: " + suddenStopScore);
        }
        else
        {
            audioSource.clip = Clips[0];
            audioSource.Play();
        }
    }
}