using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Consts
{
	public class ConstClass
	{
		public const float ScreenWidth = 1920;
		public const float ScreenHeight = 1080;
		public const float gameScreenWidth = 762;
		public const float gameScreenHeight = 994;
		public const KeyCode slowkey1 = KeyCode.JoystickButton6;
		public const KeyCode slowkey2 = KeyCode.JoystickButton4;
		public const KeyCode shootkey = KeyCode.JoystickButton0;
		public const KeyCode breatkey = KeyCode.JoystickButton8;
		public const KeyCode startkey = KeyCode.JoystickButton11;
		public const KeyCode selectkey = KeyCode.JoystickButton10;
	}
}

public class StartSetting : MonoBehaviour
{
	private void Awake()
	{
		Application.targetFrameRate = 60;
	}
}
