using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    // ����
    public int Score;
    // ���� Ƚ��
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
            print("���հ�");
        }

        if(disqulification)
        {
            print("�ǰ�");
        }
    }
}
