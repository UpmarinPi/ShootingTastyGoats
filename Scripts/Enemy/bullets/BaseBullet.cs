using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

namespace BulletConst
{
	static class AngleConst
	{
		public const float Radian = Mathf.PI / 180.0f;
	}
}

public class BaseBullet : MonoBehaviour
{
	protected Vector2 pos;
	public int speed = 2;
	protected GameObject enemyTag;
	protected KeyCode lookingEnemyKey1 = ConstClass.slowkey1;
	protected KeyCode lookingEnemyKey2 = ConstClass.slowkey2;
	protected bool lookingEnemyFlag;
	protected Vector2 bulletAngle;
	//public Color32 color;
	//SpriteRenderer spriteRenderer;

	void Start()
	{
		pos = transform.position;
		enemyTag = GameObject.FindWithTag("ECollision");

		if((Input.GetKey(lookingEnemyKey1) || Input.GetKey(lookingEnemyKey2)) && enemyTag != null)
		{
			bulletAngle = speed / 100.0f * ((Vector2) enemyTag.transform.position - pos).normalized;
		}
		else
		{
			bulletAngle = speed / 100.0f * new Vector2(0, 1);
		}
		//spriteRenderer = GetComponent<SpriteRenderer>();
	}
	private void FixedUpdate()
	{
		//spriteRenderer.color = color;
		transform.position = pos;
		CheckOutSide(this.gameObject);
	}
	/// <summary>
	/// 場外に出たか判定する関数
	/// </summary>
	/// <param name="_gameobject">判定するオブジェクト</param>
	void CheckOutSide(GameObject _gameobject)
	{
		if(_gameobject.transform.position.y > ConstClass.gameScreenHeight / 2 || _gameobject.transform.position.y < -ConstClass.gameScreenHeight / 2 || _gameobject.transform.position.x > ConstClass.gameScreenWidth / 2 || _gameobject.transform.position.x < -ConstClass.gameScreenWidth / 2)//場外判定なら自身を削除
		{
			Destroy(_gameobject);
		}
	}
}
