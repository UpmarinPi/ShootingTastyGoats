using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[SerializeField] SpawnEnemy spawnEnemy;
	[SerializeField] public int defaultTimeScore;
	public int timeScore;

	[Space]
	public int hitCount;
	[SerializeField] public int defaultShotScore;
	public int shotScore;

	[Space]
	[SerializeField] PlayerCollision playerCollision;
	[SerializeField] public int defaultHpBonus;
	public int hpBonus;

	[Space]
	public int bleatCount;
	[SerializeField] public int defaultBleatScore;
	public int bleatScore;

	uint pScore;
	public int score
	{
		get
		{
			return (int) pScore;
		}
		set
		{
			if(value >= 0)
			{
				pScore = (uint) value;
			}
			else
			{
				if((int) pScore + value > 0)
				{
					pScore = (uint) -value;
				}
				else
				{
					pScore = 0;
				}
			}
		}
	}
	Text scoreText;
	void Start()
	{
		scoreText = this.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		CalcScore();
		if(score > 99999999)
		{
			score = 99999999;
		}
	}
	private void FixedUpdate()
	{
		scoreText.text = "Score: " + score.ToString("00000000");
	}
	void CalcScore()
	{
		timeScore = defaultTimeScore * (int) (spawnEnemy.timer * 100);
		shotScore = defaultShotScore * hitCount;
		hpBonus = defaultHpBonus * playerCollision.hp;
		bleatScore = defaultBleatScore * bleatCount;

		score = timeScore + shotScore + hpBonus + bleatScore;
	}
}
