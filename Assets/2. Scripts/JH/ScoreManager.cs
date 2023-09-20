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
    public bool isClear;

    private void Awake()
    {
        instance = this;
        isClear = true;
    }
    public int Deduction(int deducScore)
    {
        Score -= deducScore;
        violationCount++;
        // 성공했는지 변수
        isClear = false;
        return Score;
    }

    private void Update()
    {
        print(isClear);
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
