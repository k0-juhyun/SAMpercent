using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBrake : MonoBehaviour
{
    public GameObject sideBrake;

    void Update()
    {
        // 부모 풀리는 예외 처리 및 스케일 튀는 현상 방지
        this.transform.SetParent(sideBrake.transform);
        this.transform.localScale = Vector3.one;

        // x 축 각도 조절
        if(this.transform.localEulerAngles.x > 180f && this.transform.localEulerAngles.x <= 360f)
        {
            this.transform.localEulerAngles = new Vector3( 0f, this.transform.localRotation.y, this.transform.localRotation.z);
        }
        else if(this.transform.localEulerAngles.x > 25f && this.transform.localEulerAngles.x < 180f)
        {
            this.transform.localEulerAngles = new Vector3( 25f, this.transform.localRotation.y, this.transform.localRotation.z);
        }

    }
}
