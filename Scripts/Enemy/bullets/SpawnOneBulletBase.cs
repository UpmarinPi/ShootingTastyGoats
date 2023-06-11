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
	[HideInInspector] public bool shotFlag;//ˆê‰ñŒ‚‚Á‚½‚ç‘¦’âŽ~‚·‚é—p‚Ìbool
	public BulletTypeEnum bullet;
	public int time;
	public int speed;
	public int angle;
	public int count;
	public bool deathBlastFlag;//Ž€–SŽž‚É’e‚ð•ú‚Â‚©‚Ç‚¤‚©
	public Color32 color = new Color32(255,255,255,255);

	public void ChangeShotFlag(bool _shotFlag)
	{
		shotFlag = _shotFlag;
	}

}
