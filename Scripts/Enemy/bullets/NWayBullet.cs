using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletConst;

public class NWayBullet : BaseBullet
{
	[SerializeField] GameObject goPlayerBulletPrefab;
	GoPlayerBullet goPlayerBullet;
	[SerializeField] int angle;//n-Way弾を1つにつきどれほどずらすか。度数法
	[SerializeField] int count;//何-way弾にするか
	float angleRadian;

	public NWayBullet Instantiate(Vector2 _pos, int _speed, int _angle, int _count)
	{
		NWayBullet obj = Instantiate(this, _pos, Quaternion.identity);
		obj.pos = _pos;
		obj.speed = _speed;
		obj.angle = _angle;
		obj.count = _count;
		return obj;
	}
	private void Start()
	{
		goPlayerBullet = goPlayerBulletPrefab.GetComponent<GoPlayerBullet>();
		if(count % 2 == 1)
		{
			for(int i = 0; i < count; i++)
			{
				//中心を0として各々のズレを求める
				int a = angle * (i - (count - 1) / 2);
				goPlayerBullet.Instantiate(pos, speed, a);
			}
		}
		else
		{
			for(int i = 0; i < count; i++)
			{
				int a = angle * (i - (count) / 2) + angle / 2;
				goPlayerBullet.Instantiate(pos, speed, a);
			}
		}
		Destroy(this.gameObject);
	}
}
