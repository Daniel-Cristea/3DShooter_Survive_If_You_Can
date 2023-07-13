using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        WriteScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        WriteScore(score);
    }

    private void WriteScore(float score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void enemyKilled(int bonus)
    {
        score += bonus;
    }
}
