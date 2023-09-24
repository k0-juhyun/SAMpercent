using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyBelt : MonoBehaviour
{
    Vector3 originPos;
    Quaternion originRot;
    // Start is called before the first frame update
    void Start()
    {
        originPos = this.transform.position;
        originRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OriginPosAndRot()
    {
        this.transform.position = originPos;
        this.transform.localRotation = originRot;
    }
}
