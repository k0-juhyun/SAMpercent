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
            print("�극��ũ");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isHazardWarningLight = true;
            print("��������");
        }
    }
    // ���ߵ��� ��������
    private void OnTriggerStay(Collider other)
    {
        // 2 ���̳��� �극��ũ�� ���������� ���
        while (!isBreak && breakLimitTime > 0)
        {
            breakLimitTime -= Time.deltaTime;

            if (breakLimitTime <= 0)
            {
                scoreManager.Deduction(suddenStopScore);
                print("2�� �̳��� �극��ũ ���� �ʾƼ� ����: " + suddenStopScore);
            }
            break;
        }

        // ���� �� 3�� �̳��� �������� Ű�� ���� ���
        while (!isHazardWarningLight && lightLimitTime > 0)
        {
            lightLimitTime -= Time.deltaTime;

            if (lightLimitTime <= 0)
            {
                scoreManager.Deduction(suddenStopScore);
                print("3��q �̳��� �������� Ű���ʾƼ� ����: " + suddenStopScore);
            }
            break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �ٽ� ��� �� �������̸� ���� ���� ���
        if (isHazardWarningLight 
            && other.gameObject.name == "CarTrigger")
        {
            scoreManager.Deduction(suddenStopScore);
            print("��� �� �������� �����ʾƼ� ����: " + suddenStopScore);
        }
    }
}
