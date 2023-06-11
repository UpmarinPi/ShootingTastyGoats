using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOneBullet : MonoBehaviour
{

	[SerializeField] GoDownBullet goDownPrefab;
	[SerializeField] GoAngleBullet goAnglePrefab;
	[SerializeField] GoPlayerBullet goPlayerPrefab;
	[SerializeField] NWayBullet nWayPrefab;
	[SerializeField] MakeCircleBullet makeCirclePrefab;

	public bool deathFlag = false;
	AudioSource audioSource;
	[SerializeField] AudioClip blastSound;
	bool finishDeathBlastFlag = false;
	public bool FinishDeathBlastFlag
	{
		get
		{
			return finishDeathBlastFlag;
		}
	}

	[SerializeField] List<SpawnOneBulletBase> spawnOneBullets = new List<SpawnOneBulletBase>();
	[SerializeField] bool loopFlag;
	int loopTimer = 0;
	SpriteRenderer spriteRenderer;
	float timer;//タイマー。各々の弾のタイマーを発動するために必要
	Vector2 pos;


	private void Start()
	{
		timer = 0;
		spriteRenderer = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		pos = transform.position;
		if(loopFlag)//ループするのならばループ最後となる弾の時間を取得
		{
			for(int i = 0; i < spawnOneBullets.Count; i++)
			{
				if(loopTimer < spawnOneBullets[i].time)
				{
					loopTimer = spawnOneBullets[i].time;
				}
			}
		}
	}
	private void Update()
	{
		pos = transform.position;
		for(int i = 0; i < spawnOneBullets.Count; i++)
		{
			SpawnOneBulletBase iBullet = spawnOneBullets[i];

			if(!iBullet.deathBlastFlag && iBullet.time / 100.0f <= timer && !iBullet.shotFlag)
			{
				InstantiateBullets(iBullet, i);
			}
			if(iBullet.deathBlastFlag && deathFlag && !iBullet.shotFlag)//弾がdeathBlastFlagのとき、死亡してまだ撃っていない場合に発動
			{
				audioSource.PlayOneShot(blastSound);
				InstantiateBullets(iBullet, i);
			}
		}
		for(int i = 0; i < spawnOneBullets.Count; i++)//全てのdeathBlastFlagを撃ち切ったとき、finishDeathBlastFlagをtrueにする。これでオブジェクトがdestroy可能になる
		{
			if(!spawnOneBullets[i].deathBlastFlag || spawnOneBullets[i].shotFlag)
			{
				finishDeathBlastFlag = true;
			}
			else
			{
				break;
			}
		}
		if(loopFlag && loopTimer / 100.0f <= timer)
		{
			ResetShotFlag();
		}
		else
		{
			timer += Time.deltaTime;
		}

	}
	public void InstantiateBullets(SpawnOneBulletBase _spawnOneBulletBase, int _i)
	{
		_spawnOneBulletBase.shotFlag = true;
		spawnOneBullets[_i] = _spawnOneBulletBase;
		switch(_spawnOneBulletBase.bullet)
		{
			case SpawnOneBulletBase.BulletTypeEnum.GoDown:
				goDownPrefab.Instantiate(pos, _spawnOneBulletBase.speed);
				break;
			case SpawnOneBulletBase.BulletTypeEnum.GoAngle:
				goAnglePrefab.Instantiate(pos, _spawnOneBulletBase.speed, _spawnOneBulletBase.angle);
				break;
			case SpawnOneBulletBase.BulletTypeEnum.GoPlayer:
				goPlayerPrefab.Instantiate(pos, _spawnOneBulletBase.speed, _spawnOneBulletBase.angle);
				break;
			case SpawnOneBulletBase.BulletTypeEnum.nWay:
				nWayPrefab.Instantiate(pos, _spawnOneBulletBase.speed, _spawnOneBulletBase.angle, _spawnOneBulletBase.count);
				break;
			case SpawnOneBulletBase.BulletTypeEnum.makeCircle:
				makeCirclePrefab.Instantiate(pos, _spawnOneBulletBase.speed, _spawnOneBulletBase.angle, _spawnOneBulletBase.count);
				break;
		}
	}
	void ResetShotFlag()
	{
		for(int i = 0; i < spawnOneBullets.Count; i++)
		{
			SpawnOneBulletBase spawnOneBulletBase = spawnOneBullets[i];
			spawnOneBulletBase.shotFlag = false;
			spawnOneBullets[i] = spawnOneBulletBase;
		}
		timer = 0;
	}

	public void SetBullets(List<SpawnOneBulletBase> _spawnOneBullets, bool _loopFlag)
	{
		spawnOneBullets = _spawnOneBullets;
		loopFlag = _loopFlag;
	}
	public void SetBullets(SpawnOneBulletBase _spawnOneBullets, bool _loopFlag)
	{
		spawnOneBullets[0] = _spawnOneBullets;
		loopFlag = _loopFlag;
	}
	//参考:enumの状況よってスクリプトの中身を変更するスクリプト
	//https://kan-kikuchi.hatenablog.com/entry/InspectorEx
}
