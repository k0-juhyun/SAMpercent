using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enumeration : MonoBehaviour
{
    public enum GearEventType
    {
        eDrive,
        eReverse,
        eNeutral,
        eParking,
        eOthers
    }

    public enum HandType
    {
        Left,
        Right
    }

}
