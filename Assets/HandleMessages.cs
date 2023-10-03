using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleMessages : MonoBehaviour
{
    private TextMeshProUGUI messages;

    private void Awake()
    {
        messages = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (HandleNavi.instance != null)
        {
            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.SeatBelt)
            {
                messages.text = "안전벨트를 착용하세요.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Forward)
            {
                messages.text = "시동을 걸고 출발하세요.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Hill)
            {
                messages.text = "언덕에서 4초간 정차하세요.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.TurnLeft)
            {
                messages.text = "좌회전 하세요.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Cross)
            {
                messages.text = "신호에 맞춰 교차로를 건너세요.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Parking)
            {
                messages.text = "주차선에 맞게 주차하세요.";
            }
        }
    }
}
