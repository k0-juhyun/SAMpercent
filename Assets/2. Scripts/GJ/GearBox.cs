using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBox : MonoBehaviour
{
    public static GearBox instance;


    private void Awake()
    {
        if (instance == null) Destroy(instance);
        instance = this;
    }

    void FixedUpdate()
    {

    }
}
