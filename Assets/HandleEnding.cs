using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleEnding : MonoBehaviour
{
    // ������ ��Ʈ
    private void OnTriggerEnter(Collider other)
    {
        if(ScoreManager.instance.Score >= 80)
        {
            // ��� �÷ο�
        }

        else if (ScoreManager.instance.Score < 80)
        {
            // Ż�� �÷ο�
        }
    }
}
