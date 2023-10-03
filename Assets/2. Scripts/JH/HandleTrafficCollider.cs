using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 신호가 빨간 불일 때 들어오면 실격
public class HandleTrafficCollider : MonoBehaviour
{
    private WheelController wheelController;
    private AudioSource audioSource;

    public bool signalViolation;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    // 신호가 빨간 불 일때 밟으면 실격
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

        audioSource.enabled = true;
    }
}


