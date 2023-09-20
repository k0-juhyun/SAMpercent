using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleNavi : MonoBehaviour
{
    public static HandleNavi instance;
    private JHCarTest carTest;
    private HandleTimernScore handleTimernScore;

    public RawImage[] flowImages;
    public RawImage currentImage;

    private WaitForSeconds updateDelay;

    private Vector3 originScale;

    // ������ enum
    public enum CurrentContent
    {
        SeatBelt,
        Forward,
        Hill,
        TurnLeft,
        Cross,
        Parking,
        End
    }

    public CurrentContent currentContent = CurrentContent.SeatBelt;

    private void Awake()
    {
        instance = this;
        carTest = GetComponentInParent<JHCarTest>();
        handleTimernScore = GetComponent<HandleTimernScore>();

        // ���� ������ ����
        originScale = flowImages[0].transform.localScale;

        // �ڷ�ƾ ȣ�� �ֱ�
        updateDelay = new WaitForSeconds(1);

        // �ڷ�ƾ ȣ��
        StartCoroutine(HandleContent());
    }

    IEnumerator HandleContent()
    {
        // �õ��� ������ ����
        while (!carTest.isEnd)
        {
            yield return updateDelay;

            switch (currentContent)
            {
                // ���÷ο쿡 ���� �����̹��� ����
                case CurrentContent.SeatBelt:
                    StatePerContent(0);
                    break;
                case CurrentContent.Forward:
                    StatePerContent(1);
                    break;
                case CurrentContent.Hill:
                    StatePerContent(2);
                    break;
                case CurrentContent.TurnLeft:
                    StatePerContent(3);
                    break;
                case CurrentContent.Cross:
                    StatePerContent(4);
                    break;
                case CurrentContent.Parking:
                    StatePerContent(5);
                    break;
                case CurrentContent.End:
                    break;
            }
        }
    }

    private void StatePerContent(int index)
    {
        currentImage.texture = flowImages[index].texture;
        flowImages[index].transform.localScale = new Vector3(0.4f, 0.7f, 0.7f);
        // ���� �̹��� �ٽ� ���� ũ���
        if(index != 0)
        {
            flowImages[index - 1].transform.localScale = originScale;
        }
    }

    public void HandleNextContent()
    {
        handleTimernScore.resetFlag = true;
        currentContent++;
    }
}
