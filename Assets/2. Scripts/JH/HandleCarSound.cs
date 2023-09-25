using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCarSound : MonoBehaviour
{
    private JHCarTest carTest;

    private void Awake()
    {
        carTest = GetComponentInParent<JHCarTest>();
    }

    private void Update()
    {
        if (GameFlowManager.instance.isSeatBelt)
            SoundManager.Instance.PlaySFX(10);
        if (carTest.isStartUp)
            SoundManager.Instance.PlaySFX(9);
    }
}
