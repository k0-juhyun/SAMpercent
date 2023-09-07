using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHCarTest : MonoBehaviour
{
    public float movePower;

    public bool isBreak;
    public bool isHazardWarningLight;
    public bool isleftTurnSignalLight;
    public bool isrightTurnSignalLight;

    public GameObject hazardWarningLight;
    public GameObject leftTurnSignalLight;
    public GameObject rightTurnSignalLight;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float V = Input.GetAxis("Vertical");
        float H = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(V, 0, -H);
        moveDirection.Normalize();
        rb.AddForce(moveDirection * movePower);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        hazardWarningLight.SetActive(isHazardWarningLight);
        leftTurnSignalLight.SetActive(isleftTurnSignalLight);
        rightTurnSignalLight.SetActive(isrightTurnSignalLight);

        #region �����̵�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBreak = true;
            print("�극��ũ");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isHazardWarningLight == false)
        {
            isHazardWarningLight = true;
            print("�������� �ѱ�");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && isHazardWarningLight)
        {
            isHazardWarningLight = false;
            print("�������� ����");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && isleftTurnSignalLight == false)
        {
            isleftTurnSignalLight = true;
            print("��ȸ�� ������ ��");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && isleftTurnSignalLight)
        {
            isleftTurnSignalLight = false;
            print("��ȸ�� ������ ��");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && isrightTurnSignalLight == false)
        {
            isrightTurnSignalLight = true;
            print("��ȸ�� ������ ��");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && isrightTurnSignalLight)
        {
            isrightTurnSignalLight = false;
            print("��ȸ�� ������ ��");
        }
        #endregion
    }
}
