using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseCounter : MonoBehaviour
{
    public Text scoreText;

    int score = 3;

    public void Start()
    {
        scoreText.text = score.ToString() + " AMOUNT";
    }

    public void AddCheeseAmount()
    {
        score += 1;
        scoreText.text = score.ToString() + " AMOUNT";
    }
    public int GetScore()
    {
        return score;
    }
}