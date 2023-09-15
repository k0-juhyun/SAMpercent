using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public List<Collider> gearList;

    private void OnTriggerEnter(Collider col)
    {
        // 주행 Drive
        if (col == gearList[0])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eDrive);
        }
        // 후진 Reverse
        else if(col == gearList[1])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eReverse);
        }
        // 중립 Neutral
        else if (col == gearList[2])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eNeutral);
        } // 주차 Parking
        else if (col == gearList[3])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eParking);
        }
    }


}
