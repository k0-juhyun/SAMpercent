using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStartLine : MonoBehaviour
{
    private AudioSource audioSource;

    private WheelController wheelController;
    private JHCarTest carTest;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        carTest = other.GetComponentInParent<JHCarTest>();
        if(carTest != null) 
        {
            audioSource.enabled = true;
            HandleNavi.instance.HandleNextContent();
            HandleNavi.instance.currentContent = HandleNavi.CurrentContent.Hill;
            print("¸î¹ø");
        }
    }
}
