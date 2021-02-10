using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField]
	private Text scoreText, coinText;

	void Start()
	{
		SetScoreForDifficulty();
	}
	void SetScoreForDifficulty()
	{
		if (GamePreferences.GetEasyDifficultyState() == 0)
		{
			SetScore(GamePreferences.GetEasyDifficultyHighscore(), GamePreferences.GetEasyDifficultyCoinScore());
		}

		if (GamePreferences.GetMediumDifficultyState() == 0)
		{
			SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinScore());
		}

		if (GamePreferences.GetHardDifficultyState() == 0)
		{
			SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinScore());
		}
	}
	public void SetScore(int score, int coin)
	{
		scoreText.text = "" + score;
		coinText.text = "" + coin;
	}
	public void GoBack()
    {
        Application.LoadLevel("MainScene");
    }

}
