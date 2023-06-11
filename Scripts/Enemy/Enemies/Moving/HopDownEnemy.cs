using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopDownEnemy : BaseEnemy
{
	public Vector2 goPos;

	void Update()
	{
		if(!finishFlag)
		{
			if(startFlag && ((!CheckApproximation(pos.x, goPos.x, 2)) || (!CheckApproximation(pos.y, goPos.y, 2))))//���ԊJ�n
			{
				pos.x = Mathf.Lerp(pos.x, goPos.x, 1 / (speed * 500 * Time.deltaTime));
				pos.y = Mathf.Lerp(pos.y, goPos.y, 1 / (speed * 500 * Time.deltaTime));
			}
			else if(startFlag)
			{
				finishFlag = true;
			}
		}
	}

	/// <summary>
	/// a��b���ߎ��l���ǂ������f�Btolerance�Ɍ덷�̋��e�͈͂����
	/// </summary>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <param name="tolerance"></param>
	/// <returns></returns>
	bool CheckApproximation(float a, float b, float tolerance)
	{
		//Debug.Log("a: " + a + ", b: " + b + ", tolerance: " + tolerance + " = " + (b <= (a + tolerance) && b >= (a - tolerance)));
		if(b <= (a + tolerance) && b >= (a - tolerance))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
