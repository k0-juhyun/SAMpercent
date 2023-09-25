using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTurnLeft : MonoBehaviour
{
    private WheelController wheelController;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        wheelController = other.GetComponentInParent<WheelController>();
        if (wheelController != null)
        {
            audioSource.enabled = true;
            HandleNavi.instance.HandleNextContent();
            HandleNavi.instance.currentContent = HandleNavi.CurrentContent.Cross;
        }
    }
}
