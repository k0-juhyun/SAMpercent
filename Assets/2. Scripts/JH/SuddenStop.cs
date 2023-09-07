using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenStop : MonoBehaviour
{
    private JHCarTest carTest;

    private int suddenStopScore = 10;

    private float breakLimitTime = 2;
    private float lightLimitTime = 3;

    // ���ߵ��� ��������
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        // 2 ���̳��� �극��ũ�� ���������� ���
        while (!carTest.isBreak && breakLimitTime > 0)
        {
            breakLimitTime -= Time.deltaTime;

            if (breakLimitTime <= 0)
            {
                ScoreManager.instance.Deduction(suddenStopScore);
                print("2�� �̳��� �극��ũ ���� �ʾƼ� ����: " + suddenStopScore);
            }
            break;
        }

        // ���� �� 3�� �̳��� �������� Ű�� ���� ���
        while (!carTest.isHazardWarningLight && lightLimitTime > 0)
        {
            lightLimitTime -= Time.deltaTime;

            if (lightLimitTime <= 0)
            {
                ScoreManager.instance.Deduction(suddenStopScore);
                print("3��q �̳��� �������� Ű���ʾƼ� ����: " + suddenStopScore);
            }
            break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �ٽ� ��� �� �������̸� ���� ���� ���
        if (carTest.isHazardWarningLight 
            && other.gameObject.name == "CarTrigger")
        {
            ScoreManager.instance.Deduction(suddenStopScore);
            print("��� �� �������� �����ʾƼ� ����: " + suddenStopScore);
        }
    }
}
