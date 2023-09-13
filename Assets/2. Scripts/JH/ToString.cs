using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToString : MonoBehaviour
{
    ScoreManager scoreHandler;
    public Text text;

    private void Awake()
    {
        scoreHandler = FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        text.text = scoreHandler.Score.ToString();
    }
}
