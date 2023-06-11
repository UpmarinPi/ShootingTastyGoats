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
	float timer;//�^�C�}�[�B�e�X�̒e�̃^�C�}�[�𔭓����邽�߂ɕK�v
	Vector2 pos;


	private void Start()
	{
		timer = 0;
		spriteRenderer = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		pos = transform.position;
		if(loopFlag)//���[�v����̂Ȃ�΃��[�v�Ō�ƂȂ�e�̎��Ԃ��擾
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
			if(iBullet.deathBlastFlag && deathFlag && !iBullet.shotFlag)//�e��deathBlastFlag�̂Ƃ��A���S���Ă܂������Ă��Ȃ��ꍇ�ɔ���
			{
				audioSource.PlayOneShot(blastSound);
				InstantiateBullets(iBullet, i);
			}
		}
		for(int i = 0; i < spawnOneBullets.Count; i++)//�S�Ă�deathBlastFlag�������؂����Ƃ��AfinishDeathBlastFlag��true�ɂ���B����ŃI�u�W�F�N�g��destroy�\�ɂȂ�
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
	//�Q�l:enum�̏󋵂���ăX�N���v�g�̒��g��ύX����X�N���v�g
	//https://kan-kikuchi.hatenablog.com/entry/InspectorEx
}
