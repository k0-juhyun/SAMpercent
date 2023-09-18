using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToString : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update()
    {
        text.text = ScoreManager.instance.Score.ToString();
    }
}
