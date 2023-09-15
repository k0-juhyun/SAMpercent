using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SAMPRO_EventManager : MonoBehaviour
{
    public static SAMPRO_EventManager instance;

    public delegate void CallBackEvent();
    public static event CallBackEvent eventCallBack;

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

    public void AddCallBackEvent(Enumeration.GearEventType gearType, CallBackEvent _event)
    {
        var callBacks = (List<CallBackEvent>)eventHash[gearType];
        if (callBacks == null)
        {
            callBacks = new List<CallBackEvent>();
            eventHash.Add(gearType, callBacks);
        }
        callBacks.Add(_event);
    }
    public void RemoveCallBackEvent(Enumeration.GearEventType gearType, CallBackEvent _event)
    {
        var callBakcs = (List<CallBackEvent>)eventHash[gearType];
        if (callBakcs != null)
            callBakcs.Remove(_event);
        else
            Debug.Log("삭제 콜백 이슈");
    }

    public void RunEvent(Enumeration.GearEventType gearType)
    {
        var callbacks = (List<CallBackEvent>)eventHash[gearType];
        if (callbacks != null)
            foreach (var callback in callbacks)
                callback();
        else
            Debug.Log("실행 콜백 이슈");

    }


}