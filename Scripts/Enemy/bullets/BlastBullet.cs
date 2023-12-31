using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBullet : BaseBullet
{
	[SerializeField] GameObject nWayPrefab;
	NWayBullet nWayBullet;
	BaseEnemy baseEnemy;
	[SerializeField] int angle;//n-Way弾を1つにつきどれほどずらすか。度数法
	[SerializeField] int count;//何-way弾にするか
	SpawnOneBulletBase spawnOneBulletBase;
	public BlastBullet Instantiate(Vector2 _pos, SpawnOneBulletBase _spawnOneBulletBase)
	{
		BlastBullet obj = Instantiate(this, _pos, Quaternion.identity);
		obj.pos = _pos;
		obj.spawnOneBulletBase = _spawnOneBulletBase;
		return obj;
	}
	private void Start()
	{
		baseEnemy = this.GetComponent<BaseEnemy>();
		nWayBullet = nWayPrefab.GetComponent<NWayBullet>();
		if(baseEnemy.finishFlag)
		{
			Destroy(this.gameObject);
		}
	}
}
