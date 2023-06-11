using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletConst;

public class GoAngleBullet : BaseBullet
{
	public int angle;
	float angleRadian;
	public GoAngleBullet Instantiate(Vector2 _pos, int _speed, int _angle)
	{
		GoAngleBullet obj = Instantiate(this, _pos, Quaternion.identity);
		obj.pos = _pos;
		obj.speed = _speed;
		obj.angle = _angle;
		return obj;
	}
	private void Start()
	{
		angleRadian = angle * AngleConst.Radian; 
	}
	void Update()
	{
		pos.x -= (float) speed / 50.0f * Mathf.Cos(angleRadian);
		pos.y -= (float) speed / 50.0f * Mathf.Sin(angleRadian);
	}
}
