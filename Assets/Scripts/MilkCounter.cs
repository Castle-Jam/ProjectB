using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkCounter : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    public Text GoalText;

    int score = 5;
    int goal = 10;


    private void Start()
    {
        scoreText.text = score.ToString() + " AMOUNT";
        GoalText.text = "GOAL: " + goal.ToString();
    }

    public void Update()
    {
        scoreText.text = score.ToString() + " AMOUNT";
        //Debug.Log(scoreText.text);
    }

    public void AddMilkAmount()
    {
        score += 1;
        scoreText.text = score.ToString() + " AMOUNT";
    }

    public void RemoveMilkAmmount()
    {
        score -= 3;
        scoreText.text = score.ToString() + " AMOUNT";
    }
    public int GetScore()
    {
        return score;
    }
    public bool IsMilkMax()
    {
        if (score == goal)
            return true;
        else
            return false;
    }
}