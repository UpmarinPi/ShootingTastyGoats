using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBullet : BaseBullet
{
	[SerializeField] GameObject nWayPrefab;
	NWayBullet nWayBullet;
	BaseEnemy baseEnemy;
	[SerializeField] int angle;//n-Way�e��1�ɂ��ǂ�قǂ��炷���B�x���@
	[SerializeField] int count;//��-way�e�ɂ��邩
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
