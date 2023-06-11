using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleatResult : ResultScoreBase
{
	[SerializeField] PlayerCollision playerCollision;
	void Update()
	{
		defaultScore = score.defaultBleatScore;
		count = score.bleatCount;
		totalScore = score.bleatScore;
	}
}
