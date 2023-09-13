using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHCarTest : MonoBehaviour
{
    public float movePower;

    public bool isStartUp;
    public bool isBreak;
    public bool isHazardWarningLight;
    public bool isleftTurnSignalLight;
    public bool gaerP;
    public bool isIn1stLine;
    public bool isIn2ndLine;
    public bool isSeatBelt;
    public bool isHeadLight;
    public bool isHightBeam;
    public bool isLowBeam;
    public bool isWiper;
    public bool isSideBreak = true;
    public bool isEnd;

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

        print(moveDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        hazardWarningLight.SetActive(isHazardWarningLight);
        leftTurnSignalLight.SetActive(isleftTurnSignalLight);
        rightTurnSignalLight.SetActive(gaerP);

        #region ±ôºýÀÌµé
        if (Input.GetKey(KeyCode.Space))
        {
            isBreak = true;
            print("ºê·¹ÀÌÅ©");
        }

        else
        {
            isBreak = false;
        }

        if (Input.GetKeyDown(KeyCode.F1) && isHazardWarningLight == false)
        {
            isHazardWarningLight = true;
            print("ºñ»ó±ôºýÀÌ ÄÑ±â");
        }

        else if (Input.GetKeyDown(KeyCode.F1) && isHazardWarningLight)
        {
            isHazardWarningLight = false;
            print("ºñ»ó±ôºýÀÌ ²ô±â");
        }

        if (Input.GetKeyDown(KeyCode.F2) && isleftTurnSignalLight == false)
        {
            isleftTurnSignalLight = true;
            print("ÁÂÈ¸Àü ±ôºýÀÌ ÄÔ");
        }

        else if (Input.GetKeyDown(KeyCode.F2) && isleftTurnSignalLight)
        {
            isleftTurnSignalLight = false;
            print("ÁÂÈ¸Àü ±ôºýÀÌ ²û");
        }

        if (Input.GetKeyDown(KeyCode.F3) && gaerP == false)
        {
            gaerP = true;
            print("¿ìÈ¸Àü ±ôºýÀÌ ÄÔ");
        }

        else if (Input.GetKeyDown(KeyCode.F3) && gaerP)
        {
            gaerP = false;
            print("¿ìÈ¸Àü ±ôºýÀÌ ²û");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isStartUp == false)
        {
            print("½Ãµ¿ ÄÔ");
            isStartUp = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("°ÔÀÓ ²û");
            isStartUp = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isSeatBelt == false)
        {
            print("¾ÈÀü º§Æ® ¸â");
            isSeatBelt = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("¾ÈÀü º§Æ® ¾È¸â");
            isSeatBelt = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && isHeadLight == false)
        {
            print("ÀüÁ¶µî ÄÔ");
            isHeadLight = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isHeadLight = false;
            print("ÀüÁ¶µî ²û" + isHeadLight);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && isHightBeam == false)
        {
            print("»óÇâµî ÄÔ");
            isHightBeam = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("»óÇâµî ²û");
            isHightBeam = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && isLowBeam == false)
        {
            print("ÇÏÇâµî ÄÔ");
            isLowBeam = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            print("ÇÏÇâµî ²û");
            isLowBeam = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && isWiper == false)
        {
            print("¿ÍÀÌÆÛ ÄÔ");
            isWiper = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("¿ÍÀÌÆÛ ²û");
            isWiper = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && isSideBreak == false)
        {
            print("»çÀÌµåºê·¹ÀÌÅ© ÄÔ");
            isSideBreak = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            print("»çÀÌµåºê·¹ÀÌÅ© ²û");
            isSideBreak = false;
        }
        #endregion
    }

    private void OnTriggerStay(Collider other)
    {
        #region Â÷¼± ÁÖÇàÁß
        if (other.gameObject.name == "1stLine")
        {
            isIn1stLine = true;
            isIn2ndLine = false;
        }
        if (other.gameObject.name == "2ndLine")
        {
            isIn2ndLine = true;
            isIn1stLine = false;
        }
        #endregion
    }
}
