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

    // �����ؼ� ���̵� �극��ũ �ø���
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
                print("2�� ����");
            }
            break;
        }
    }

    // ���� ������ ������ ���̵� �극��ũ �ٽ� ��������
    private void OnTriggerExit(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        // ���̵� �극��ũ�� �ö�������
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
