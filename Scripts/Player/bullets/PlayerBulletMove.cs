using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : BaseBullet
{
	void Update()
	{
		pos += bulletAngle;
	}
}
