using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	AudioSource audioSource;
	[SerializeField] GameObject resultUI;
	[SerializeField] AudioClip deathSound;
	[SerializeField] AudioClip goatCrySound;
	[SerializeField] float rotateSpeed = 10;

	bool finishDeathFlag;
	public bool deathFlag;//playerCollision‚É‰½‚©“–‚½‚Á‚½‚çtrue‚É‚È‚é
						  // Start is called before the first frame update
	void Start()
	{
		finishDeathFlag = false;
		audioSource = GetComponent<AudioSource>();
		deathFlag = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(deathFlag)
		{
			if(!finishDeathFlag)
			{
				finishDeathFlag = true;
				resultUI.SetActive(true);
				audioSource.PlayOneShot(goatCrySound);
				audioSource.PlayOneShot(deathSound);
			}
			transform.Rotate(0, 0, rotateSpeed);
		}
	}
}
