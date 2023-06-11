using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultRank : MonoBehaviour
{
	[System.Serializable]
	public class Rank
	{
		public string rank;
		public int score;
	}
	Text scoreText;
	[SerializeField] Score score;
	string rank;
	[SerializeField] List<Rank> ranks = new List<Rank>();
	void Start()
	{
		scoreText = this.GetComponent<Text>();
	}
	private void FixedUpdate()
	{
		for(int i = 0; i < ranks.Count; i++)
		{
			if(score.score >= ranks[i].score)
			{
				rank = ranks[i].rank;
				break;
			}
		}
		scoreText.text = rank.PadLeft(9);
	}
}
