using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSidewayEnemy : BaseEnemy
{
	[SerializeField] bool leftFlag;//左へ進むならtrue,右ならばfalse
	void Update()
	{
		if(startFlag && !finishFlag)
		{
			if(leftFlag)
			{
				pos.x -= speed / 50.0f;
			}
			else
			{
				pos.x += speed / 50.0f;
			}
		}
	}
}
