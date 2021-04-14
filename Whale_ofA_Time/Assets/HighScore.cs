using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    int highScore;
    public Text highScoreText;
    public int currentScore;
    public void HighScoreCheck()
    {

        if(PlayerPrefs.GetInt("HighScore") == 0)
        {
            highScore = 0;
        }
        else
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        if(highScore <= currentScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); 
        }


        highScoreText.text = highScore.ToString();
    }
}
