using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class SpawnEnemy : MonoBehaviour
{
	[SerializeField] PlayerDeath playerDeath;
	[SerializeField] List<SpawnEnemyBase> spawnEnemy = new List<SpawnEnemyBase>();
	[HideInInspector] public float timer;//�^�C�}�[�B�e�X�̒e�̃^�C�}�[�𔭓����邽�߂ɕK�v
	AudioSource audioSource;
	[SerializeField] AudioClip goatCrySound;
	[SerializeField] GameObject resultUI;
	public bool startFlag;
	public bool finishFlag;
	bool finishFinishFlag;//finishFlag�̒��ň��̂ݔ���������������


	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		timer = 0;
		startFlag = false;
		finishFlag = false;
		finishFinishFlag = false;
	}
	private void Update()
	{
		if(Input.GetKeyDown(ConstClass.startkey))
		{
			startFlag = true;
		}
		if(!startFlag)
		{
			return;
		}
		for(int i = 0; i < spawnEnemy.Count; i++)
		{
			SpawnEnemyBase iEnemy = spawnEnemy[i];

			if(iEnemy.time / 100.0f <= timer && !iEnemy.shotFlag)
			{
				InstantiateEnemies(iEnemy, i);
			}
		}
		if(timer >= 80)
		{
			finishFlag = true;
		}
		if(finishFlag)
		{
			if(!finishFinishFlag)//�I������x�̂ݔ���
			{
				finishFinishFlag = true;

				GameObject[] eCollisions = GameObject.FindGameObjectsWithTag("ECollision");
				foreach(GameObject gameObj in eCollisions)
				{
					Destroy(gameObj);
				}

				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach(GameObject gameObj in enemies)
				{
					Destroy(gameObj);
				}
				resultUI.SetActive(true);
				audioSource.PlayOneShot(goatCrySound);
			}
		}
		if(!playerDeath.deathFlag)
		{
			timer += Time.deltaTime;
		}

	}
	void InstantiateEnemies(SpawnEnemyBase _spawnEnemyBase, int _i)
	{
		_spawnEnemyBase.shotFlag = true;
		spawnEnemy[_i] = _spawnEnemyBase;
		if(spawnEnemy[_i].needInitHopDownEnemyFlag)
		{
			InitHopDownEnemy(ref spawnEnemy[_i].enemyPrefab, spawnEnemy[_i].hopDownEnemyVariable.goPos);
		}
		GameObject spawnOneBulletGO = Instantiate(spawnEnemy[_i].enemyPrefab, spawnEnemy[_i].pos, Quaternion.identity);
		Debug.Log("spawn!!!!!!");
		if(spawnEnemy[_i].makeSpecialBullet)
		{
			SpawnOneBullet spawnOneBullet = spawnOneBulletGO.GetComponent<SpawnOneBullet>();
			spawnOneBullet.SetBullets(_spawnEnemyBase.spawnOneBullets, _spawnEnemyBase.bulletLoopFlag);
		}
	}
	void InitHopDownEnemy(ref GameObject _spawnEnemyPrefab, Vector2 _goPos)
	{
		HopDownEnemy hopDownEnemy = _spawnEnemyPrefab.GetComponent<HopDownEnemy>();
		if(hopDownEnemy != null)
		{
			hopDownEnemy.goPos = _goPos;
		}
	}

	private void InitGoCircleEnemy(ref GameObject _spawnEnemyPrefab, GoCircleEnemyVariable _goCircleEnemyVariable)
	{
		GoCircleEnemy goCircleEnemy = _spawnEnemyPrefab.GetComponent<GoCircleEnemy>();
		if(goCircleEnemy != null)
		{
			goCircleEnemy.r = _goCircleEnemyVariable.r;
			goCircleEnemy.angle = _goCircleEnemyVariable.angle;
			goCircleEnemy.modificationToEllipse = _goCircleEnemyVariable.modificationToEllipse;
		}
	}
	//�Q�l:enum�̏󋵂���ăX�N���v�g�̒��g��ύX����X�N���v�g
	//https://kan-kikuchi.hatenablog.com/entry/InspectorEx
}
