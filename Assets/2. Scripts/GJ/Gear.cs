using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public List<Collider> gearList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("hi");

        if (col == gearList[0])
        {
            Debug.Log("gear");
            SAMPRO_EventManager.instance.RunEvent(Enumeration.GearEventType.eDrive);
        }
    }

    public void SetDriveEvent(Enumeration.GearEventType gearEventType)
    {

    }

}
