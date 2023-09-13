using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAMPRO_EventManager : MonoBehaviour
{
    public static SAMPRO_EventManager instance;

    public delegate void CallbackEvent();

    public static event CallbackEvent eventCallBack;

    private void SetSingleton()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }
}