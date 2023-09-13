using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
