using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighscore : MonoBehaviourSingleton<LoadHighscore>
{
    public Text highscoreText;
    public int highscore;

    private void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
            highscoreText.text = "HighScore: " + highscore.ToString();
        }
        else
        {
            highscore = 0;
            highscoreText.text = "HighScore: " + highscore.ToString();
        }
    }

    //public void getHighscore()
    //{
        
    //}
}
