using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHCarTest : MonoBehaviour
{
    public bool isStartUp;
    public bool isHazardWarningLight;
    public bool isleftTurnSignalLight;
    public bool gaerP;
    public bool isIn1stLine;
    public bool isIn2ndLine;
    public bool isHeadLight;
    public bool isHightBeam;
    public bool isLowBeam;
    public bool isWiper;
    public bool isSideBreak = true;
    public bool isEnd;
    public bool isBreak;

    private void Update()
    {
        #region �����̵�

        if (Input.GetKeyDown(KeyCode.F1) && isHazardWarningLight == false)
        {
            isHazardWarningLight = true;
            print("�������� �ѱ�");
        }

        else if (Input.GetKeyDown(KeyCode.F1) && isHazardWarningLight)
        {
            isHazardWarningLight = false;
            print("�������� ����");
        }

        //if (Input.GetKeyDown(KeyCode.F2) && isleftTurnSignalLight == false)
        //{
        //    isleftTurnSignalLight = true;
        //    print("��ȸ�� ������ ��");
        //}

        //else if (Input.GetKeyDown(KeyCode.F2) && isleftTurnSignalLight)
        //{
        //    isleftTurnSignalLight = false;
        //    print("��ȸ�� ������ ��");
        //}

        //if (Input.GetKeyDown(KeyCode.F3) && gaerP == false)
        //{
        //    gaerP = true;
        //    print("��ȸ�� ������ ��");
        //}

        //else if (Input.GetKeyDown(KeyCode.F3) && gaerP)
        //{
        //    gaerP = false;
        //    print("��ȸ�� ������ ��");
        //}

        //if (Input.GetKeyDown(KeyCode.Escape) && isStartUp == false)
        //{
        //    print("�õ� ��");
        //    isStartUp = true;
        //}

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("���� ��");
            isStartUp = false;
        }

        //if (Input.GetKeyDown(KeyCode.Alpha2) && isHeadLight == false)
        //{
        //    print("������ ��");
        //    isHeadLight = true;
        //}

        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    isHeadLight = false;
        //    print("������ ��" + isHeadLight);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3) && isHightBeam == false)
        //{
        //    print("����� ��");
        //    isHightBeam = true;
        //}

        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    print("����� ��");
        //    isHightBeam = false;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha4) && isLowBeam == false)
        //{
        //    print("����� ��");
        //    isLowBeam = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4)) 
        //{
        //    print("����� ��");
        //    isLowBeam = false;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha5) && isWiper == false)
        //{
        //    print("������ ��");
        //    isWiper = true;
        //}

        //else if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    print("������ ��");
        //    isWiper = false;
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6) && isSideBreak == false)
        //{
        //    print("���̵�극��ũ ��");
        //    isSideBreak = true;
        //}

        //else if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    print("���̵�극��ũ ��");
        //    isSideBreak = false;
        //}
        #endregion
    }

    private void OnTriggerStay(Collider other)
    {
        #region ���� ������
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
