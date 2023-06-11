using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCircleEnemy : BaseEnemy
{
	public int r;
	public float angle;//初期角度位置。
	public float modificationToEllipse;//楕円変形変数。楕円上に動かす場合、ここの値を変更する。1未満で横長、1以上で縦長状に動く


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