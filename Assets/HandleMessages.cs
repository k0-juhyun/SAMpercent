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
                messages.text = "������Ʈ�� �����ϼ���.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Forward)
            {
                messages.text = "�õ��� �ɰ� ����ϼ���.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Hill)
            {
                messages.text = "������� 4�ʰ� �����ϼ���.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.TurnLeft)
            {
                messages.text = "��ȸ�� �ϼ���.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Cross)
            {
                messages.text = "��ȣ�� ���� �����θ� �ǳʼ���.";
            }

            if (HandleNavi.instance.currentContent == HandleNavi.CurrentContent.Parking)
            {
                messages.text = "�������� �°� �����ϼ���.";
            }
        }
    }
}
