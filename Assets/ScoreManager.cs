using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class ScoreManager : MonoBehaviour {

    public int score;
    public int highScore;
    public int totalScore;

    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI lastScoreText;
    //public TextMeshProUGUI highScoreText;

    private void Awake()
    {
        //highScore = PlayerPrefs.GetInt("AnimalHighScore", 0);
        //totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        //scoreText.text = score.ToString();
        //lastScoreText.text = score.ToString();
        //highScoreText.text = highScore.ToString();
    }

    public void ScoreUp(int _inc)
    {
        //score += _inc;
        //if (score > highScore)
        //{
        //    highScore = score;
        //}
        //totalScore += _inc;
        //Write();
        //scoreText.text = score.ToString();
        //lastScoreText.text = score.ToString();
        //highScoreText.text = highScore.ToString();
        //Debug.Log("Total:"+totalScore);
    }

    private void Write()
    {
        //PlayerPrefs.SetInt("AnimalHighScore", highScore);
        //PlayerPrefs.SetInt("TotalScore", totalScore);
    }

}
