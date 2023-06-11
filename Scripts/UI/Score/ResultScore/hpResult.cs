using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpResult : ResultScoreBase
{
	[SerializeField] PlayerCollision playerCollision;
	void Update()
	{
		defaultScore = score.defaultHpBonus;
		count = playerCollision.hp;
		totalScore = score.hpBonus;
	}
}
