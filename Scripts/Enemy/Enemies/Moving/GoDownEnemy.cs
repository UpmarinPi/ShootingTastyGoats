using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDownEnemy : BaseEnemy
{
	void Update()
	{
		if(startFlag && !finishFlag)
		{
			pos.y -= (float) speed / 50.0f;
		}
	}
}
