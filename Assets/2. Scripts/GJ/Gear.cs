using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public List<Collider> gearList;
    public GameObject gearParent;

    private void OnTriggerEnter(Collider col)
    {
        // 주행 Drive
        if (col == gearList[0])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eParking);
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
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eDrive);
        }
    }

    private void Update()
    {
        // 부모 풀리는 예외 처리 및 스케일 튀는 현상 방지
        this.transform.SetParent(gearParent.transform);
        this.transform.localScale = Vector3.one;

        this.transform.localPosition = new Vector3(Mathf.Clamp(this.transform.localPosition.x, -0.0675f, -0.005f), 1.335f, Mathf.Clamp(this.transform.localPosition.z, 0.6125f, 0.845f));
    }


}
