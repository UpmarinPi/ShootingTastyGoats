using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletConst;

public class GoPlayerBullet : BaseBullet
{
	Vector2 pPos;//プレイヤー判定の中心点
	public int changeAngle = 0;//プレイヤーから何度ずらすか。加算するほど反時計回りにずれていく
	[SerializeField] int angle;//結果何度になったか。インスペクターの表示だけで特に意味はない
	float angleRadian;
	float changeAngleRadian;

	public GoPlayerBullet Instantiate(Vector2 _pos, int _speed, int _angle)
	{
		GoPlayerBullet obj = Instantiate(this, _pos, Quaternion.identity);
		obj.pos = _pos;
		obj.speed = _speed;
		obj.changeAngle = _angle;
		return obj;
	}
	private void Start()
	{
		pPos = GameObject.FindGameObjectWithTag("PCollision").transform.position;

		changeAngleRadian = changeAngle * AngleConst.Radian;

		//x,yのタンジェントより角度を求める。そこにズレ変数を加算
		angleRadian = Mathf.Atan2(transform.position.y - pPos.y, transform.position.x - pPos.x) + changeAngleRadian;

		angle = (int) (angleRadian / AngleConst.Radian);//度数法に直す。見るだけで特に意味はない
	}
	void Update()
	{
		pos.x -= (float) speed / 50.0f * Mathf.Cos(angleRadian);
		pos.y -= (float) speed / 50.0f * Mathf.Sin(angleRadian);
	}
}
