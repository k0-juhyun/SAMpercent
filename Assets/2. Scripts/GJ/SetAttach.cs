using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttach : MonoBehaviour
{
    public Transform lh, rh;

    public void Update()
    {
        this.transform.position = rh.transform.position;
        this.transform.rotation = rh.transform.rotation;
    }
}
