using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public static int HighScore;
    public GameObject HighScorePanel;
    public Text HighScoretext;

    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    // Update is called once per frame
    public void PlayerDie()
    {
        if (PlayerPrefs.GetInt("HighScore") < SnakePart.points)
        {
            PlayerPrefs.SetInt("HighScore", SnakePart.points);
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowHighScore()
    {
        HighScoretext.text = HighScore.ToString();
        HighScorePanel.SetActive(true);
    }

    public void HideHighScore()
    {
        HighScorePanel.SetActive(false);
    }
}
