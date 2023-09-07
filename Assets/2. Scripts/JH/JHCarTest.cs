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

        #region ±ôºýÀÌµé
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBreak = true;
            print("ºê·¹ÀÌÅ©");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isHazardWarningLight == false)
        {
            isHazardWarningLight = true;
            print("ºñ»ó±ôºýÀÌ ÄÑ±â");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && isHazardWarningLight)
        {
            isHazardWarningLight = false;
            print("ºñ»ó±ôºýÀÌ ²ô±â");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && isleftTurnSignalLight == false)
        {
            isleftTurnSignalLight = true;
            print("ÁÂÈ¸Àü ±ôºýÀÌ ÄÔ");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && isleftTurnSignalLight)
        {
            isleftTurnSignalLight = false;
            print("ÁÂÈ¸Àü ±ôºýÀÌ ²û");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && isrightTurnSignalLight == false)
        {
            isrightTurnSignalLight = true;
            print("¿ìÈ¸Àü ±ôºýÀÌ ÄÔ");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && isrightTurnSignalLight)
        {
            isrightTurnSignalLight = false;
            print("¿ìÈ¸Àü ±ôºýÀÌ ²û");
        }
        #endregion
    }
}
