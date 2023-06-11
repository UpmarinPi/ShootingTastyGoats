using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletConst;

public class GoPlayerBullet : BaseBullet
{
	Vector2 pPos;//�v���C���[����̒��S�_
	public int changeAngle = 0;//�v���C���[���牽�x���炷���B���Z����قǔ����v���ɂ���Ă���
	[SerializeField] int angle;//���ʉ��x�ɂȂ������B�C���X�y�N�^�[�̕\�������œ��ɈӖ��͂Ȃ�
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

		//x,y�̃^���W�F���g���p�x�����߂�B�����ɃY���ϐ������Z
		angleRadian = Mathf.Atan2(transform.position.y - pPos.y, transform.position.x - pPos.x) + changeAngleRadian;

		angle = (int) (angleRadian / AngleConst.Radian);//�x���@�ɒ����B���邾���œ��ɈӖ��͂Ȃ�
	}
	void Update()
	{
		pos.x -= (float) speed / 50.0f * Mathf.Cos(angleRadian);
		pos.y -= (float) speed / 50.0f * Mathf.Sin(angleRadian);
	}
}
