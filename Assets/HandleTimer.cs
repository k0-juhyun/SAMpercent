using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HandleTimer : MonoBehaviour
{
    // 구간별 타이머랑 토탈 타이머
    public float totalTimer = 0;
    public float sectionTimer= 0;
    public TextMeshProUGUI totalTimerText;
    public TextMeshProUGUI sectionTimerText;

    void Start()
    {
        
    }

    void Update()
    {
        totalTimer += Time.deltaTime;
        sectionTimer += Time.deltaTime;

        totalTimerText.text = totalTimer.ToString();
        sectionTimerText.text = sectionTimer.ToString();
    }
}
