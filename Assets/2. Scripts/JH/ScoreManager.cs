using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    // 총점
    public int Score;
    // 위반 횟수
    public int violationCount;

    public bool disqulification;

    private void Awake()
    {
        instance = this;
    }
    public int Deduction(int deducScore)
    {
        Score -= deducScore;
        violationCount++;
        return Score;
    }

    private void Update()
    {
        if(Score < 80) 
        {
            print("불합격");
        }

        if(disqulification)
        {
            print("실격");
        }
    }
}
