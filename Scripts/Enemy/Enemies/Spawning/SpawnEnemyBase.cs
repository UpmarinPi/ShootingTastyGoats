using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEnemyBase
{
	[HideInInspector] public bool shotFlag;//一回インスタンスしたら即停止する用のbool
	public GameObject enemyPrefab;
	public Vector2 pos = new Vector2(0, 550);
	public int time;

	[Header("HopDownEnemy用")]
	public bool needInitHopDownEnemyFlag;
	public HopDownEnemyVariable hopDownEnemyVariable;

	[Header("GoCircleEnemy用")]
	public bool needInitGoCircleEnemyFlag;
	public GoCircleEnemyVariable goCircleEnemyVariable;

	[Space]
	public bool makeSpecialBullet;
	public List<SpawnOneBulletBase> spawnOneBullets = new List<SpawnOneBulletBase>();
	public bool bulletLoopFlag;

}

[System.Serializable]
public class HopDownEnemyVariable
{
	public Vector2 goPos = new Vector2(0, 550);
}

[System.Serializable]
public class GoCircleEnemyVariable
{
	public int r;
	public float angle;//初期角度位置。
	public float modificationToEllipse = 1;//楕円変形変数。楕円上に動かす場合、ここの値を変更する。1未満で横長、1以上で縦長状に動く
}