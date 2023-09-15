using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GearBox : MonoBehaviour
{
    public static GearBox instance;

    Enumeration.GearEventType gearType;


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
        //SAMPRO_EventManager.instance
    }

    private void RemoveEvent()
    {

    }

    public void onDrive()
    {
        gearType = Enumeration.GearEventType.eDrive;
    }
    public void onNeutral()
    {
        gearType = Enumeration.GearEventType.eNeutral;
    }
    public void onReverse()
    {
        gearType = Enumeration.GearEventType.eReverse;
    }
    public void onParking()
    {
        gearType = Enumeration.GearEventType.eParking;
    }
}
