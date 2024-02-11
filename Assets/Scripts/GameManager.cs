using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int health;
    public static int highScore;

    public TMP_Text scoreText;
    public TMP_Text healthText;

    private void Start()
    {
        score = 0;
        highScore = 0;
        health = 3;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }
}
