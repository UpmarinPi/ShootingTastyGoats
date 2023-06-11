using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBullet : BaseBullet
{
	[SerializeField] GameObject nWayPrefab;
	NWayBullet nWayBullet;
	BaseEnemy baseEnemy;
	[SerializeField] int angle;//n-WayíeÇ1Ç¬Ç…Ç¬Ç´Ç«ÇÍÇŸÇ«Ç∏ÇÁÇ∑Ç©ÅBìxêîñ@
	[SerializeField] int count;//âΩ-wayíeÇ…Ç∑ÇÈÇ©
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
