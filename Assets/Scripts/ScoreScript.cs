using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public ComboScript comboScript;

    private void Update()
    {
        scoreText.text = "   " + score;
    }

    public void AddScore()
    {
        score += 100 * comboScript.combo;
    }

    public void SubtractScore()
    {
        score -= 10;
    }
}
