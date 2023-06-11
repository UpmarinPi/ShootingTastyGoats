using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotResult : ResultScoreBase
{
	void Update()
	{
		defaultScore = score.defaultShotScore;
		count = score.hitCount;
		totalScore = score.shotScore;
	}
}
