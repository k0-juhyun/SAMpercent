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

    // 콘텐츠 enum
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

        // 원래 스케일 저장
        originScale = flowImages[0].transform.localScale;

        // 코루틴 호출 주기
        updateDelay = new WaitForSeconds(1);

        // 코루틴 호출
        StartCoroutine(HandleContent());
    }

    IEnumerator HandleContent()
    {
        // 시동이 꺼질때 까지
        while (!carTest.isEnd)
        {
            yield return updateDelay;

            switch (currentContent)
            {
                // 각플로우에 따라 시험이미지 변경
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
            // 이전 이미지 다시 원래 크기로
            if (index != 0)
            {
                flowImages[index - 1].transform.localScale = originScale;

                // 성공하면 성공 텍스쳐 실패하면 실패텍스쳐
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
