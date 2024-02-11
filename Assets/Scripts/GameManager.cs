using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int health = 3;
    public static int highScore;

    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text highScoreText;

    public GameObject overScreen;

    private void Start()
    {
        score = 0;
        highScore = 0;
        health = 3;
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();

        if (score  > highScore)
        {
            highScore = score;
            highScoreText.text = "High score: " + highScore.ToString();
        }
        if (health <= 0)
        {
            overScreen.SetActive(true);
        }
    }
}
