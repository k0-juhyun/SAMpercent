using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToString : MonoBehaviour
{
    ScoreManager scoreManager;
    public Text text;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        text.text = scoreManager.Score.ToString();
    }
}
