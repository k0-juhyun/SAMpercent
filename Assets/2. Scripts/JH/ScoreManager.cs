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
        // �����ߴ��� ����
        isClear = false;
        return Score;
    }

    private void Update()
    {
        print(isClear);
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
