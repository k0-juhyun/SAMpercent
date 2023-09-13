using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

// 1차선에 있다가 2차선으로 차선을 변경할때
// 즉 중앙선을 넘어갈때
// 깜빡이가 안켜져 있으면 감점
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
            #region 컴포넌트 가져옴
            leftTurnLight = 
                other.gameObject.GetComponent<JHCarTest>().isleftTurnSignalLight;
            rightTurnLight = 
                other.gameObject.GetComponent<JHCarTest>().gaerP;
            isIn1stLine =
                other.gameObject.GetComponent<JHCarTest>().isIn1stLine;
            isIn2ndLine =
                other.gameObject.GetComponent<JHCarTest>().isIn2ndLine;
            #endregion

            // 1차선 -> 2차선 우회전 깜빡이
            if(isIn1stLine && rightTurnLight == false)
            {
                print("우회전 깜빡이 안켜서 감점");
                ScoreManager.instance.Deduction(dontTurnOnLight);
            }

            // 2차선 -> 1차선 좌회전 깜빡이
            if(isIn2ndLine && leftTurnLight == false)
            {
                print("좌회전 깜빡이 안켜서 감점");
                ScoreManager.instance.Deduction(dontTurnOnLight);
            }
        }
    }
}
