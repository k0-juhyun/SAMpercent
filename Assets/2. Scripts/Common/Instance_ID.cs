using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Instance_ID : MonoBehaviour
{
    public Collider myCol;
    public GameObject leftHand, rightHand;

    // Start is called before the first frame update
    private void Start()
    {
        if (this.transform.GetComponent<Collider>() != null)
        {
            myCol = this.transform.GetComponent<Collider>();
        }

        if (this.transform.GetComponentsInChildren<SkinnedMeshRenderer>() != null)
        {
            leftHand = this.transform.GetChild(0).gameObject;
            rightHand = this.transform.GetChild(1).gameObject;
        }
    }

}