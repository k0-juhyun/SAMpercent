using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int Score;

    public bool disqulification;

    private void Awake()
    {
        instance = this;
    }
    public int Deduction(int deducScore)
    {
        Score -= deducScore;
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
