using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class Bleat : MonoBehaviour
{
	AudioSource audioSource;
	[SerializeField] SpawnEnemy spawnEnemy;
	[SerializeField] PlayerDeath playerDeath;
	[SerializeField] AudioClip breatSound;
	[SerializeField] Score score;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if(!playerDeath.deathFlag && Input.GetKeyDown(ConstClass.breatkey))
		{
			audioSource.PlayOneShot(breatSound);
			if(spawnEnemy.startFlag)
			{
				score.bleatCount++;
			}
		}
	}
}
