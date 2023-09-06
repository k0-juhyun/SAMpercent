using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    public int Deduction(int deducScore)
    {
        Score -= deducScore;
        return Score;
    }
}
