using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShower : MonoBehaviour
{
    public Text yourScore, highScore;

    void Start()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        yourScore.text = "Your Score: " + Mathf.RoundToInt(scoreManager.GetScore());
        highScore.text = "High Score: " + Mathf.RoundToInt(scoreManager.GetHighScore());
    }
}
