using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class PlayerShootBase : MonoBehaviour
{
	public enum BulletTypeEnum
	{
		singleShot = 0,
	}
	SingleShot singleShot;
	KeyCode shootKey = ConstClass.shootkey;
	public BulletTypeEnum bulletType;

	bool shooting;
	void Start()
	{
		singleShot = this.GetComponent<SingleShot>();
		shooting = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKey(shootKey))
		{
			shooting = true;
		}
		else
		{
			shooting = false;
		}
	}
	private void FixedUpdate()
	{
		switch(bulletType)
		{
			case BulletTypeEnum.singleShot:
				singleShot.shootingFlag = shooting;
				break;
		}
	}
}
