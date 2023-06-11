using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	Score score;
	float deathXpos;
	protected Vector2 startPos;
	protected Vector2 pos;
	[SerializeField] protected int maxHp;
	int hp;
	protected float timer;
	[SerializeField] protected int time;
	[SerializeField] protected int speed = 2;
	[SerializeField] protected Vector2 alivePos = new Vector2(455, 555);
	[SerializeField] float rotateSpeed = 10;

	[Space]
	AudioSource audioSource;
	[SerializeField] AudioClip shootSound;
	[SerializeField] AudioClip hitSound;
	[SerializeField] AudioClip deathSound;
	[SerializeField] AudioClip blastSound;

	SpawnOneBullet spawnOneBullet;

	protected bool startFlag = false;
	bool finishDeathFlag;//死亡時一度だけ発動する
	[HideInInspector] public bool finishFlag = false;

	void Start()
	{
		score = GameObject.FindWithTag("Score").GetComponent<Score>();
		spawnOneBullet = GetComponent<SpawnOneBullet>();
		audioSource = GetComponent<AudioSource>();
		startPos = transform.position;
		pos = transform.position;
		hp = maxHp;
		timer = 0;
		deathXpos = Random.Range(-10.0f, 10.0f);
		finishDeathFlag = false;
	}
	private void FixedUpdate()
	{
		if(time / 100.0f <= timer && !startFlag)
		{
			pos = transform.position;
			startFlag = true;
		}
		if(startFlag)
		{
			transform.position = pos;//継承したオブジェがポジションをいじる
			CheckOutSide(this.gameObject);
			if(hp <= 0)
			{
				finishFlag = true;
				spawnOneBullet.deathFlag = true;
				if(spawnOneBullet.FinishDeathBlastFlag)
				{
					Death();
				}
			}
		}
		timer += Time.deltaTime;

	}

	/// <summary>
	/// 場外に出たか判定する関数
	/// </summary>
	/// <param name="_gameobject">判定するオブジェクト</param>
	void CheckOutSide(GameObject _gameobject)
	{
		if(_gameobject.transform.position.y > alivePos.y || _gameobject.transform.position.y < -alivePos.y || _gameobject.transform.position.x > alivePos.x || _gameobject.transform.position.x < -alivePos.x)//場外判定なら自身を削除
		{
			Destroy(_gameobject);
		}
	}
	void Death()
	{
		if(!finishDeathFlag)
		{
			finishDeathFlag = true;
			score.hitCount += 10;
			audioSource.PlayOneShot(deathSound);
		}
			transform.Rotate(0, 0, rotateSpeed);
			pos += new Vector2(deathXpos, 10);
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.CompareTag("PBullet") && hp > 0)
		{
			audioSource.PlayOneShot(hitSound);
			score.hitCount++;
			hp--;
		}
	}
}
