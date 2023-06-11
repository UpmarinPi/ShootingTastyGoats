using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText: MonoBehaviour
{
	[SerializeField] SpawnEnemy spawnEnemy;

	Text timeText;
	void Start()
	{
		timeText = this.GetComponent<Text>();
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		if(spawnEnemy.startFlag)
		{
			timeText.text = "Time: " + spawnEnemy.timer.ToString("000000000");
		}
		else
		{
			timeText.text = "Time: èÄîıíÜ";
		}
	}
}
