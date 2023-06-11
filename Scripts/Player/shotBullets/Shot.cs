using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
	public GameObject bulletPrefab;
	[HideInInspector] public bool shootingFlag;
	public bool chargeMode;
	protected int waitTimer;//クールタイムを過ぎたかどうかのタイマー。0の時は発射可能
	[SerializeField] int waitTime;//クールタイム
	protected bool chargeFlag;//チャージモードをオンにするか
	[SerializeField] int chargeTime;//チャージモードオン時、チャージ完了時どれほど待つか  
	protected AudioSource audioSource;
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		shootingFlag = false;
	}
	public void StartTimer()
	{
		waitTimer++;
	}
	protected void ShotFixedUpdate()//別々にfixedupdateは呼び出せないので、子クラスにやってもらう
	{
		if(waitTimer != 0)
		{
			if(waitTimer >= waitTime)
			{
				waitTimer = 0;
			}
			else
			{
				waitTimer++;
			}
		}
	}
}
