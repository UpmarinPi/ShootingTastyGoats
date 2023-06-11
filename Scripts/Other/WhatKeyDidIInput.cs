using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatKeyDidIInput : MonoBehaviour
{
	public bool joyStickFlag { get; private set; }

	// Update is called once per frame
	void Update()
	{
		if(Input.anyKeyDown)
		{
			foreach(KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
			{
				if(Input.GetKeyDown(code))
				{
					if(code.ToString().Contains("Joystick"))
					{
						joyStickFlag = true;
					}
					else
					{
						joyStickFlag = false;
					}
					// ���͂��ꂽ�L�[����\��
					Debug.Log(code.ToString() + ": " + joyStickFlag);
				}
			}
		}
	}
}
