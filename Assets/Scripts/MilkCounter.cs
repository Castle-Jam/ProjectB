using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkCounter : MonoBehaviour
{
    public Text scoreText;
    public Text GoalText;

    int score = 0;
    int goal = 10;


    private void Start()
    {
        scoreText.text = score.ToString() + " AMOUNT";
        GoalText.text = "GOAL: " + goal.ToString();
    }

    public void AddMilkAmount()
    {
        score += 1;
        scoreText.text = score.ToString() + " AMOUNT";
    }
}