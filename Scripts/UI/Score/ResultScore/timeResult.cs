using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeResult : ResultScoreBase
{
	[SerializeField] SpawnEnemy spawnEnemy;
	void Update()
	{
		defaultScore = score.defaultTimeScore;
		count = (int) (spawnEnemy.timer * 100);
		totalScore = score.timeScore;
	}
}
