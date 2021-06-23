using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    protected ScoreManager() { }

    public float score;
    [SerializeField] public Text scoreText;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        setScoreText();
    }

    public void AddPointsToScore()
    {
        score += 10;
    }

    void setScoreText()
    {
        scoreText.text = score.ToString();
    }
}
