using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class HandleNavi : MonoBehaviour
{
    public static HandleNavi instance;
    private JHCarTest carTest;
    private HandleTimernScore handleTimernScore;

    public RawImage[] flowImages;

    public Texture[] ingTexture;
    public Texture[] clearTexture;
    public Texture[] failTexture;

    public RawImage currentImage;

    private WaitForSeconds updateDelay;

    private Vector3 originScale;

    public bool isNext;

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
        flowImages[index].texture = ingTexture[index];
        currentImage.texture = flowImages[index].texture;
        flowImages[index].transform.localScale = new Vector3(0.4f, 0.7f, 0.7f);
        if (isNext)
        {
            // ���� �̹��� �ٽ� ���� ũ���
            if (index != 0)
            {
                flowImages[index - 1].transform.localScale = originScale;

                // �����ϸ� ���� �ؽ��� �����ϸ� �����ؽ���
                if (ScoreManager.instance.isClear)
                {
                    flowImages[index - 1].texture = clearTexture[index - 1];
                }
                else
                {
                    flowImages[index - 1].texture = failTexture[index - 1];
                    ScoreManager.instance.isClear = true;
                }
            }
            isNext = false;
        }
    }

    public void HandleNextContent()
    {
        handleTimernScore.resetFlag = true;
        isNext = true;
    }

}
