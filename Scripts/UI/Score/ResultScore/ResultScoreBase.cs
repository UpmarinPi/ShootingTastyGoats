using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreBase : MonoBehaviour
{
	Text scoreText;
	[SerializeField] protected Score score;
	protected int defaultScore;
	protected int count;
	[SerializeField] protected int totalScore;
	void Start()
	{
		scoreText = this.GetComponent<Text>();
	}
	private void FixedUpdate()
	{
		if(totalScore != 0)
		{
			scoreText.text = count.ToString() + "x" + defaultScore.ToString() + ": " + totalScore.ToString().PadLeft(8);
		}
		else
		{
			scoreText.text = totalScore.ToString().PadLeft(8);
		}
	}
}
