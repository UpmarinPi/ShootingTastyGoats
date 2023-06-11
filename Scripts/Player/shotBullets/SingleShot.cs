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
		if(shootingFlag)//���ˏ�Ԃ̂Ƃ�
		{
			switch(chargeFlag)//�`���[�W���[�h�ɂ���ċ�����ύX
			{
				case false:
					if(waitTimer == 0)
					{
						StartTimer();//�^�C�}�[����
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
