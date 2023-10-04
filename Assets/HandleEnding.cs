using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleEnding : MonoBehaviour
{
    public GameObject happyUI, badUI;
    // ������ ��Ʈ
    private void OnTriggerEnter(Collider other)
    {
        if(ScoreManager.instance.Score >= 80)
        {
            // ��� �÷ο�
            happyUI.SetActive(true);
        }

        else if (ScoreManager.instance.Score < 80)
        {
            // Ż�� �÷ο�
            badUI.SetActive(true);
        }
    }
}
