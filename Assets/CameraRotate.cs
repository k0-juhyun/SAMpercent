using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float rx, ry;
    public float rotSpeed = 200f;

    private void Update()
    {
        //1. 사용자의 마우스 입력을 누적하고싶다.
        //2. 그 누적값으로 x,y 축을 회전하고싶다.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rx += mx * rotSpeed * Time.deltaTime;
        ry += my * rotSpeed * Time.deltaTime;

        ry = Mathf.Clamp(ry, -75, 75);

        //회전값을 적용한다.
        transform.eulerAngles = new Vector3(-ry, rx, 0);
    }
}