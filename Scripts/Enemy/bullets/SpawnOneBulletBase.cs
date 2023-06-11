using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnOneBulletBase
{
	public enum BulletTypeEnum
	{
		GoDown,
		GoAngle,
		GoPlayer,
		nWay,
		makeCircle,
	}
	[HideInInspector] public bool shotFlag;//��񌂂����瑦��~����p��bool
	public BulletTypeEnum bullet;
	public int time;
	public int speed;
	public int angle;
	public int count;
	public bool deathBlastFlag;//���S���ɒe������ǂ���
	public Color32 color = new Color32(255,255,255,255);

	public void ChangeShotFlag(bool _shotFlag)
	{
		shotFlag = _shotFlag;
	}

}
