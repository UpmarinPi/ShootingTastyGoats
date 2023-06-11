using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Shot
{
	[SerializeField] AudioClip singleShotSound;
	[SerializeField] PlayerDeath playerDeath;
	private void FixedUpdate()
	{
		if(playerDeath.deathFlag)
		{
			return;
		}
		ShotFixedUpdate();
		if(shootingFlag)//発射状態のとき
		{
			switch(chargeFlag)//チャージモードによって挙動を変更
			{
				case false:
					if(waitTimer == 0)
					{
						StartTimer();//タイマー発動
						audioSource.PlayOneShot(singleShotSound);
						Instantiate(bulletPrefab, transform.position, Quaternion.identity);
					}
					break;
				case true:

					break;
			}
		}
	}
}
