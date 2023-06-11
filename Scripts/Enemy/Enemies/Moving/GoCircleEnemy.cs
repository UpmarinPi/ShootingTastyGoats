using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCircleEnemy : BaseEnemy
{
	public int r;
	public float angle;//�����p�x�ʒu�B
	public float modificationToEllipse;//�ȉ~�ό`�ϐ��B�ȉ~��ɓ������ꍇ�A�����̒l��ύX����B1�����ŉ����A1�ȏ�ŏc����ɓ���


	void Update()
	{
		if(startFlag && !finishFlag)
		{
			angle += speed / 50.0f;
			pos.x = startPos.x + r * Mathf.Cos(angle * Mathf.Deg2Rad);
			pos.y = startPos.y + r * Mathf.Sin(angle * Mathf.Deg2Rad) * modificationToEllipse;
		}
	}
}