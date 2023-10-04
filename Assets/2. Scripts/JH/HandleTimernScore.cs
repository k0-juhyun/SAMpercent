using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HandleTimernScore : MonoBehaviour
{
    // 구간별 타이머랑 토탈 타이머
    public float totalTimer = 0;
    public float sectionTimer = 0;

    public TextMeshProUGUI totalTimerText;
    public TextMeshProUGUI sectionTimerText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI violation;
    public TextMeshProUGUI gearType;

    float totalSec;
    float totalMin;
    float sectionSec;
    float sectionMin;

    string totalTimestr;
    string sectionTimestr;

    [HideInInspector]
    public bool resetFlag;

    void Update()
    {
        if (resetFlag)
        {
            sectionTimer = 0;
            resetFlag = false;
        }

        if (SoundManager.Instance != null)
        {
            totalTimer += Time.deltaTime;
            sectionTimer += Time.deltaTime;

            totalMin = (int)totalTimer / 60;
            totalSec = (int)totalTimer % 60;

            sectionMin = (int)sectionTimer / 60;
            sectionSec = (int)sectionTimer % 60;

            totalTimestr = totalMin.ToString("00") + ":" + totalSec.ToString("00");
            sectionTimestr = sectionMin.ToString("00") + ":" + sectionSec.ToString("00");

            totalTimerText.text = totalTimestr.ToString();
            sectionTimerText.text = sectionTimestr.ToString();

            score.text = ScoreManager.instance.Score.ToString();
            violation.text = ScoreManager.instance.violationCount.ToString();
        }
    }
}
