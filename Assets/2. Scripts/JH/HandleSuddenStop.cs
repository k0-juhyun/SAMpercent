using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSuddenStop : MonoBehaviour
{
    private JHCarTest carTest;

    private int suddenStopScore = 10;

    private float breakLimitTime = 2;
    private float lightLimitTime = 3;

    // �극��ũ�� �������� �ִ��� Ȯ��
    private bool isBreakPushed;

    // ���ߵ��� ��������
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();

        if (carTest.isBreak)
            isBreakPushed = true;
        
        // 2 ���̳��� �극��ũ�� ���������� ���
        while (!carTest.isBreak && breakLimitTime > 0 && !isBreakPushed)
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
        if (carTest.isBreak)
        {
            while (!carTest.isHazardWarningLight && lightLimitTime > 0)
            {
                lightLimitTime -= Time.deltaTime;

                if (lightLimitTime <= 0)
                {
                    ScoreManager.instance.Deduction(suddenStopScore);
                    print("3�� �̳��� �������� Ű���ʾƼ� ����: " + suddenStopScore);
                }
                break;
            }
        }
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
    }
}