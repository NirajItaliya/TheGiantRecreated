using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();
    }

    void Awake()
    {
        MakeSingleton();
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "Gameplay")
        {

            if (gameRestartedAfterPlayerDied)
            {
                GamePlayController.instance.SetScore(score);
                GamePlayController.instance.SetLifeScore(lifeScore);
                GamePlayController.instance.SetCoinScore(coinScore);

                PlayerScore.coinCount = coinScore;
                PlayerScore.scoreCount = score;
                PlayerScore.lifeCount = lifeScore;

            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.coinCount = 0;
                PlayerScore.scoreCount = 0;
                PlayerScore.lifeCount = 2;

                GamePlayController.instance.SetScore(0);
                GamePlayController.instance.SetLifeScore(2);
                GamePlayController.instance.SetCoinScore(0);

            }

        }
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitializeGame()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetMusicState(1);

            GamePreferences.SetEasyDifficultyState(1);
            GamePreferences.SetEasyDifficultyHighscore(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);

            GamePreferences.SetMediumDifficultyState(0);
            GamePreferences.SetMediumDifficultyHighscore(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);

            GamePreferences.SetHardDifficultyState(1);
            GamePreferences.SetHardDifficultyHighscore(0);
            GamePreferences.SetHardDifficultyCoinScore(0);

            PlayerPrefs.SetInt("Game Initialized", 0);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            if (GamePreferences.GetEasyDifficultyState() == 0)
            {

                int highscore = GamePreferences.GetEasyDifficultyHighscore();
                int highCoinScore = GamePreferences.GetEasyDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetEasyDifficultyHighscore(score);

                if (highCoinScore < coinScore)
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);

            }

            if (GamePreferences.GetMediumDifficultyState() == 0)
            {

                int highscore = GamePreferences.GetMediumDifficultyHighscore();
                int highCoinScore = GamePreferences.GetMediumDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetMediumDifficultyHighscore(score);

                if (highCoinScore < coinScore)
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);

            }

            if (GamePreferences.GetHardDifficultyState() == 0)
            {

                int highscore = GamePreferences.GetHardDifficultyHighscore();
                int highCoinScore = GamePreferences.GetHardDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetHardDifficultyHighscore(score);

                if (highCoinScore < coinScore)
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);

            }
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;
            
            GamePlayController.instance.GameOverShowPanel(score, coinScore );

        } 
        else 
        {

            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            GamePlayController.instance.SetScore(score);
            GamePlayController.instance.SetLifeScore(lifeScore);
            GamePlayController.instance.SetCoinScore(coinScore);

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GamePlayController.instance.PlayerDiedRestartLevel();


        }
    }
}
