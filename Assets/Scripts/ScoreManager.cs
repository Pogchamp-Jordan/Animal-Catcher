using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score = 0, highScore = 0;
    private bool startCountingScore = false;

    public float GetScore()
    {
        return score;
    }

    public float GetHighScore()
    {
        return highScore;
    }

    private void Update()
    {
        if (startCountingScore)
        {
            score += Time.deltaTime;
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SetCountingScore(bool value)
    {
        startCountingScore = value;

        if (!value)
        {
            if (score > highScore)
            {
                highScore = score;
            }
        }
    }
}
