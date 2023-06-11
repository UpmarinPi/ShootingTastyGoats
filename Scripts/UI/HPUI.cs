using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
	[SerializeField] PlayerCollision playerCollision;
	[SerializeField] int thisHP;
	bool showFlag;
	Image image;

	Color32 hideColor = new Color32(255,255,255,0);
	Color32 showColor = new Color32(255,255,255,255);
	private void Start()
	{
		image = GetComponent<Image>();
	}
	private void Update()
	{
		if(playerCollision.hp < thisHP)
		{
			showFlag = false;
		}
		else
		{
			showFlag = true;
		}
	}
	private void FixedUpdate()
	{
		if(showFlag)
		{
			image.color = showColor;
		}
		else
		{
			image.color = hideColor;
		}
	}
}
