using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDownBullet : BaseBullet
{
	public GoDownBullet Instantiate(Vector2 _pos, int _speed)
	{
		GoDownBullet obj = Instantiate(this, _pos, Quaternion.identity);
		obj.pos = _pos;
		obj.speed = _speed;
		return obj;
	}
	void Update()
	{
		pos.y -= speed / 50.0f;
	}
}
