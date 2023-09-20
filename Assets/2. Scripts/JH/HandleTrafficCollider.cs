using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ȣ�� ���� ���� �� ������ �ǰ�
public class HandleTrafficCollider : MonoBehaviour
{
    private WheelController wheelController;

    public bool signalViolation;

    // ��ȣ�� ���� �� �϶� ������ �ǰ�
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        wheelController = other.GetComponentInParent<WheelController>();

        if (wheelController != null)
        {
            print(other.gameObject.name);
            signalViolation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wheelController = other.GetComponentInParent<WheelController>();

        if (wheelController != null)
        {
            print(other.gameObject.name);
            if (this.gameObject.name == "1")
            {
                HandleNavi.instance.HandleNextContent();
                HandleNavi.instance.currentContent = HandleNavi.CurrentContent.Parking;
            }
            signalViolation = false;
        }
    }
}


