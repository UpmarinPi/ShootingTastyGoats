using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletConst;

public class MakeCircleBullet : BaseBullet
{
	[SerializeField] GameObject goAngleBulletPrefab;
	GoAngleBullet goAngleBullet;
	[SerializeField] int angle;
	[SerializeField] int count;//�e�����o����

	public MakeCircleBullet Instantiate(Vector2 _pos, int _speed , int _angle, int _count)
	{
		MakeCircleBullet obj = Instantiate(this, _pos, Quaternion.identity);
		obj.pos = _pos;
		obj.speed = _speed;
		obj.angle = _angle;
		obj.count = _count;
		return obj;
	}
	private void Start()
	{
		goAngleBullet = goAngleBulletPrefab.GetComponent<GoAngleBullet>();
		for(int i = 0; i < count; i++)
		{
			//���S��0�Ƃ��Ċe�X�̃Y�������߂�
			goAngleBullet.Instantiate(pos, speed, 360 / count * i + angle);
		}
		Destroy(this.gameObject);
	}
}
