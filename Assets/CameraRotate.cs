using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float rx, ry;
    public float rotSpeed = 200f;

    private void Update()
    {
        //1. ������� ���콺 �Է��� �����ϰ�ʹ�.
        //2. �� ���������� x,y ���� ȸ���ϰ�ʹ�.
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        rx += mx * rotSpeed * Time.deltaTime;
        ry += my * rotSpeed * Time.deltaTime;

        ry = Mathf.Clamp(ry, -75, 75);

        //ȸ������ �����Ѵ�.
        transform.eulerAngles = new Vector3(-ry, rx, 0);
    }
}