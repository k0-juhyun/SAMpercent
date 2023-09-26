using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyBelt : MonoBehaviour
{
    private Vector3 originPos;
    private Quaternion originRot;

    // Start is called before the first frame update
    private void Start()
    {
        originPos = this.transform.position;
        originRot = this.transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OriginPosAndRot()
    {
        this.transform.position = originPos;
        this.transform.localRotation = originRot;
    }
}