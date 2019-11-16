using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;


    public void IncrementScore(int increment)
    { 
        score += increment;
        if (score < 0) score = 0;
        scoreText.text = score.ToString();
    }
}
