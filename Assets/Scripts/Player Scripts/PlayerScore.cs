using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private Camerascript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int lifeCount;
	public static int coinCount;
	public static int scoreCount;

	void Awake()
	{
		cameraScript = Camera.main.GetComponent<Camerascript>();
	}

	void Start()
	{
		previousPosition = transform.position;
		countScore = true;
	}

	void Update()
	{
		CountScore();
	}

	void CountScore()
	{
		if (countScore)
		{
			if (transform.position.y < previousPosition.y)
			{
				scoreCount++;
				
			}

			previousPosition = transform.position;
			GamePlayController.instance.SetScore(scoreCount);
		}
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Coin")
		{
			coinCount++;
			scoreCount += 200;
			

			GamePlayController.instance.SetScore(scoreCount);
			GamePlayController.instance.SetCoinScore(coinCount);

			AudioSource.PlayClipAtPoint(coinClip, target.transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Life")
		{
			lifeCount++;
			scoreCount += 300;

			GamePlayController.instance.SetLifeScore(lifeCount);
			GamePlayController.instance.SetScore(scoreCount);


			AudioSource.PlayClipAtPoint(lifeClip, target.transform.position);
			target.gameObject.SetActive(false);
			

		}

		if (target.tag == "Bounds")
		{
			cameraScript.moveCamera = false;
			countScore = false;
			transform.position = new Vector3(500, 500, 0);
			lifeCount--;
			GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
		}

		if (target.tag == "Deadly")
		{
			cameraScript.moveCamera = false;
			countScore = false;
			transform.position = new Vector3(500, 500, 0);
			lifeCount--;
		    GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

		}
	}


}
