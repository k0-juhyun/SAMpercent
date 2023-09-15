using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SAMPRO_EventManager;

public class SAMPRO_EventManager : MonoBehaviour
{
    public static SAMPRO_EventManager instance;

    public delegate void CallbackEvent();
    public static event CallbackEvent eventCallBack;

    public Hashtable eventHash = new Hashtable();
    
    private void SetSingleton()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }

    public void AddCallBackEvent(Enumeration.GearEventType gearType, CallbackEvent _event)
    {
        //var callBacks = (List<CallBackEvent>)eventHash[gearType];
        //if (callBacks == null)
        //{
        //    callBacks = new List<CallBackEvent>();
        //    eventHash.Add(gearType, callBacks);
        //}
        //callBacks.Add(_event);
    }
}