using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleEnding : MonoBehaviour
{
    public GameObject happyUI, badUI;
    // 마무리 멘트
    private void OnTriggerEnter(Collider other)
    {
        if(ScoreManager.instance.Score >= 80)
        {
            // 통과 플로우
            happyUI.SetActive(true);
        }

        else if (ScoreManager.instance.Score < 80)
        {
            // 탈락 플로우
            badUI.SetActive(true);
        }
    }
}
