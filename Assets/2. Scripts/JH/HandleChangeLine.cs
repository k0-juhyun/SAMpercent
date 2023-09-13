using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

// 1������ �ִٰ� 2�������� ������ �����Ҷ�
// �� �߾Ӽ��� �Ѿ��
// �����̰� ������ ������ ����
public class HandleChangeLine : MonoBehaviour
{
    private bool leftTurnLight;
    private bool rightTurnLight;
    private bool isIn1stLine;
    private bool isIn2ndLine;

    private int dontTurnOnLight = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<JHCarTest>() != null)
        {
            #region ������Ʈ ������
            leftTurnLight = 
                other.gameObject.GetComponent<JHCarTest>().isleftTurnSignalLight;
            rightTurnLight = 
                other.gameObject.GetComponent<JHCarTest>().gaerP;
            isIn1stLine =
                other.gameObject.GetComponent<JHCarTest>().isIn1stLine;
            isIn2ndLine =
                other.gameObject.GetComponent<JHCarTest>().isIn2ndLine;
            #endregion

            // 1���� -> 2���� ��ȸ�� ������
            if(isIn1stLine && rightTurnLight == false)
            {
                print("��ȸ�� ������ ���Ѽ� ����");
                ScoreManager.instance.Deduction(dontTurnOnLight);
            }

            // 2���� -> 1���� ��ȸ�� ������
            if(isIn2ndLine && leftTurnLight == false)
            {
                print("��ȸ�� ������ ���Ѽ� ����");
                ScoreManager.instance.Deduction(dontTurnOnLight);
            }
        }
    }
}
