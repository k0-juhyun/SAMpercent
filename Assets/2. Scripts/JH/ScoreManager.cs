using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }
    public int Deduction(int deducScore)
    {
        audioSource.Play();
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
