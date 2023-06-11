using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlash : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	Color32 normalColor;
	Color32 flashColor;
	bool flashColorFlag;
	[SerializeField] int flashSpeed;
	float flashTimer;
	PlayerCollision playerCollision;
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerCollision = transform.GetChild(0).GetComponent<PlayerCollision>();
		normalColor = spriteRenderer.color;
		flashColorFlag = false;
	}

	void Update()
	{
		if(playerCollision.invincibleFlag)
		{
			flashTimer += Time.deltaTime;
			if(flashTimer >= flashSpeed / 100)
			{
				flashTimer = 0;
				flashColorFlag = !flashColorFlag;
			}
		}
		else
		{
			flashColorFlag = false;
		}

	}
	private void FixedUpdate()
	{
		if(flashColorFlag)
		{
			spriteRenderer.color = flashColor;
		}
		else
		{
			spriteRenderer.color = normalColor;
		}
	}
}
