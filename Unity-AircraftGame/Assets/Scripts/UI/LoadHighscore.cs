using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighscore : MonoBehaviourSingleton<LoadHighscore>
{
    public Text highscoreText;
    public int highscore;

    public override void Awake()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "HighScore: " + highscore.ToString();
    }
}
