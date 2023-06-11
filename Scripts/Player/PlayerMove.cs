using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] PlayerDeath playerDeath;
	[SerializeField] SpawnEnemy spawnEnemy;
	KeyCode leftKey = KeyCode.LeftArrow;
	KeyCode rightKey = KeyCode.RightArrow;
	KeyCode downKey = KeyCode.DownArrow;
	KeyCode upKey = KeyCode.UpArrow;
	KeyCode slowKey1 = ConstClass.slowkey1;
	KeyCode slowKey2 = ConstClass.slowkey2;

	public int speed = 2;
	public int slowSpeed = 2;//Šî‚Ì”’l‚É‚±‚ê‚ğœZ‚·‚éB‚Â‚Ü‚è‘å‚«‚­‚·‚é‚Ù‚Çslow‚É’x‚­‚È‚é

	Vector2 pos;
	int slowRatio;//slow‚Íslowspeed,‚»‚¤‚Å‚È‚¢ê‡‚Í1‚ª“ü‚é

	private void Start()
	{
		pos = transform.position;
	}
	private void Update()
	{
		if(playerDeath.deathFlag || spawnEnemy.finishFlag)
		{
			return;
		}
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		if(Input.GetKey(slowKey1) || Input.GetKey(slowKey2))
		{
			slowRatio = slowSpeed;
		}
		else
		{
			slowRatio = 1;
		}
		if(h > 0.5 || h < -0.5)
		{
			pos.x = BetweenTwoNumber(pos.x + speed * h / slowRatio / 100.0f, -ConstClass.gameScreenWidth / 2, ConstClass.gameScreenWidth / 2);
		}
		if(v > 0.5 || v < -0.5)
		{
		pos.y = BetweenTwoNumber(pos.y + speed * v / slowRatio / 100.0f, -ConstClass.gameScreenHeight / 2, ConstClass.gameScreenHeight / 2);
		}
		//if(Input.GetKey(leftKey))
		//{
		//	pos.x = Mathf.Max(pos.x - (float) speed / slowRatio / 100.0f, -ConstClass.gameScreenWidth / 2);
		//}
		//if(Input.GetKey(rightKey))
		//{
		//	pos.x = Mathf.Min(pos.x + (float) speed / slowRatio / 100.0f, ConstClass.gameScreenWidth / 2);
		//}
		//if(Input.GetKey(downKey))
		//{
		//	pos.y = Mathf.Max(pos.y - (float) speed / slowRatio / 100.0f, -ConstClass.gameScreenHeight / 2);
		//}
		//if(Input.GetKey(upKey))
		//{
		//	pos.y = Mathf.Min(pos.y + (float) speed / slowRatio / 100.0f, ConstClass.gameScreenHeight / 2);
		//}
	}
	private void FixedUpdate()
	{
		transform.position = pos;
	}
	float BetweenTwoNumber(float a, float min, float max)//“ñ‚Â‚ÌŠÔ‚Ì”B
	{
		if(a < min)
		{
			return min;
		}
		else if(a > max)
		{
			return max;
		}
		else
		{
			return a;
		}
	}
}
