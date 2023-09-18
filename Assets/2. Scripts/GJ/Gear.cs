using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public List<Collider> gearList;
    public GameObject gearParent;

    private void OnTriggerEnter(Collider col)
    {
        // ���� Drive
        if (col == gearList[0])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eParking);
        }
        // ���� Reverse
        else if(col == gearList[1])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eReverse);
        }
        // �߸� Neutral
        else if (col == gearList[2])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eNeutral);
        } // ���� Parking
        else if (col == gearList[3])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eDrive);
        }
    }

    private void Update()
    {
        // �θ� Ǯ���� ���� ó�� �� ������ Ƣ�� ���� ����
        this.transform.SetParent(gearParent.transform);
        this.transform.localScale = Vector3.one;

        this.transform.localPosition = new Vector3(Mathf.Clamp(this.transform.localPosition.x, -0.0675f, -0.005f), 1.335f, Mathf.Clamp(this.transform.localPosition.z, 0.6125f, 0.845f));
    }


}
