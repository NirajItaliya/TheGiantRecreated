using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance; 

    [SerializeField]
    private Text scoreText, lifeScore, coinScore, gameOverScoreText, gameOverCoinScoreText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

    void Awake()
    {
        MakeInstance();
        //		Time.timeScale = 0f;
    }

    void Start()
    {
        Time.timeScale = 0f;
    } 

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void GameOverShowPanel(int gameOverScore, int gameOverCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "" + gameOverScore;
        gameOverCoinScoreText.text = "" + gameOverCoinScore;
        StartCoroutine(GameOverLoadMainMenu());
    }

    public void PlayerDiedRestartLevel()
    {
        StartCoroutine(PlayerDiedRestart());
    }
    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        Application.LoadLevel("Gameplay");
    }
    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("MainScene");

    }
    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void SetCoinScore(int score)
    {
        coinScore.text = "x" + score;
    }

    public void SetLifeScore(int score)
    {
        lifeScore.text = "x" + score;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
       // Application.LoadLevel("MainScene");
        Application.LoadLevel ("MainScene");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
