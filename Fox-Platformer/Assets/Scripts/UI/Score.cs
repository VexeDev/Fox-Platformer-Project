using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int currentScore;
    int highScore;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        currentScoreText.text = "Score: 0";
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void UpdateScore ()
    {
        currentScoreText.text = "Score: " + currentScore.ToString();
        PlayerPrefs.SetInt("currentScore", currentScore);

        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", currentScore);
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
        UpdateScore();
    }
}
