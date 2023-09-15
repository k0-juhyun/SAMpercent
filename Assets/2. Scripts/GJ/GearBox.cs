using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GearBox : MonoBehaviour
{
    public static GearBox instance;
    public Enumeration.GearEventType gearType;

    private void Awake()
    {
        if (instance == null) Destroy(instance);
        instance = this;
    }

    private void Start()
    {
        AddEvent();
    }
    private void OnDestroy()
    {
        RemoveEvent();
    }

    private void AddEvent()
    {
        SAMPRO_EventManager.instance.AddCallBackEvent(Enumeration.GearEventType.eDrive, onDrive);
        SAMPRO_EventManager.instance.AddCallBackEvent(Enumeration.GearEventType.eReverse, onReverse);
        SAMPRO_EventManager.instance.AddCallBackEvent(Enumeration.GearEventType.eNeutral, onNeutral);
        SAMPRO_EventManager.instance.AddCallBackEvent(Enumeration.GearEventType.eParking, onParking);
    }

    private void RemoveEvent()
    {
        SAMPRO_EventManager.instance.RemoveCallBackEvent(Enumeration.GearEventType.eDrive, onDrive);
        SAMPRO_EventManager.instance.RemoveCallBackEvent(Enumeration.GearEventType.eReverse, onReverse);
        SAMPRO_EventManager.instance.RemoveCallBackEvent(Enumeration.GearEventType.eNeutral, onNeutral);
        SAMPRO_EventManager.instance.RemoveCallBackEvent(Enumeration.GearEventType.eParking, onParking);
    }

    public void onDrive()
    {
        gearType = Enumeration.GearEventType.eDrive;
        Debug.Log("Drive");
    }

    public void onReverse()
    {
        gearType = Enumeration.GearEventType.eReverse;
    }

    public void onNeutral()
    {
        gearType = Enumeration.GearEventType.eNeutral;
    }

    public void onParking()
    {
        gearType = Enumeration.GearEventType.eParking;
    }
}
