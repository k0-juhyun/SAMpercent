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

    private void OnTriggerStay(Collider other)
    {
        wheelController = other.GetComponentInParent<WheelController>();

        print(other.gameObject.name);
        // 4�� ���� �����ؾ��Ѵ�
        while (stopTime > 0 && wheelController.leftStop)
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
}
