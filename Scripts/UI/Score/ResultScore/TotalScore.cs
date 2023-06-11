using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
	Text scoreText;
	[SerializeField] Score score;
	void Start()
	{
		scoreText = this.GetComponent<Text>();
	}
	private void FixedUpdate()
	{
		scoreText.text = score.score.ToString().PadLeft(9);
	}
}
