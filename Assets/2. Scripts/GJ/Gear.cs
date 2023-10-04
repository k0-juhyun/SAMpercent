using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public List<Collider> gearList;
    public List<Collider> gearMeshes;
    public Collider gearMesh;
    public GameObject gearParent;

    private void Start()
    {
        //var col = gearMesh.GetComponents<Collider>();
        //foreach (Collider col in gearMeshes)
        //{
        //    gearMeshes.Add(col);
        //}
    }

    private void OnTriggerEnter(Collider col)
    {
        // ���� Drive
        if (col == gearList[0])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eParking);
        }
        // ���� Reverse
        else if (col == gearList[1])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eReverse);
        }
        // �߸� Neutral
        else if (col == gearList[2])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eNeutral);
        }
        // ���� Parking
        else if (col == gearList[3])
        {
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eDrive);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == gearMeshes[0] || other == gearMeshes[1] || other == gearMeshes[2] || other == gearMeshes[3] || other == gearMeshes[4])
        {
            this.transform.localPosition = new Vector3(Mathf.Clamp(this.transform.localPosition.x, -0.0045f, 0.005f), 0f, Mathf.Clamp(this.transform.localPosition.z, -0.035f, 0f));
        }
    }

    private void Update()
    {
        // �θ� Ǯ���� ���� ó�� �� ������ Ƣ�� ���� ����
        this.transform.SetParent(gearParent.transform);
        this.transform.localScale = Vector3.one;
        //this.transform.localPosition = new Vector3(Mathf.Clamp(this.transform.localPosition.x, -0.0045f, 0.005f), 0f, Mathf.Clamp(this.transform.localPosition.z, -0.035f, 0f));
    }
}