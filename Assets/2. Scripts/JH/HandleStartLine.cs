using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStartLine : MonoBehaviour
{
    private AudioSource audioSource;

    private WheelController wheelController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        wheelController = other.GetComponentInParent<WheelController>();
        if(wheelController != null ) 
        {
            audioSource.enabled = true;
            HandleNavi.instance.HandleNextContent();
            HandleNavi.instance.currentContent = HandleNavi.CurrentContent.Hill;
            print("¸î¹ø");
        }
    }
}
