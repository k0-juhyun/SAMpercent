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
    // ���� �ð�
    private float stopTime = 4;

    private int hillScore = 5;
    private void OnTriggerStay(Collider other)
    {
        carTest = other.GetComponentInParent<JHCarTest>();
        if (carTest == null)
            return;
        wheelController = other.GetComponentInParent<WheelController>();

        print(other.gameObject.name);

        // wheelController.leftstop
        // 4�� ���� �����ؾ��Ѵ�
        while (stopTime > 0 && carTest.isBreak)
        {
            stopTime -= Time.deltaTime;

            if (stopTime <= 0)
            {
                print("4�� ����");
                SoundManager.Instance.PlaySFX(1);
            }
            break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
