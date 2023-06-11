using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;
using UnityEngine.SceneManagement;

public class CursorSelect : MonoBehaviour
{
	enum StartExitEnum
	{
		start,
		exit,
		none,
	}
	[SerializeField] float rightPos;
	[SerializeField] float leftPos;
	[SerializeField] int speed;
	[SerializeField] SelectedButton startButton;
	[SerializeField] SelectedButton exitButton;
	[SerializeField] FlushController flushController;
	AudioSource audioSource;
	[SerializeField] AudioClip goatCrySound;
	RectTransform rectTransform;
	StartExitEnum startExit;
	Vector2 nowPos;
	float goingPosX;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		rectTransform = GetComponent<RectTransform>();
		nowPos = transform.position;
		goingPosX = 0;
		startExit = StartExitEnum.none;
	}
	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		if(h > 0.5)
		{
			goingPosX = rightPos;
			startExit = StartExitEnum.exit;
			exitButton.selectedFlag = true;
		}
		else
		{
			exitButton.selectedFlag = false;
		}
		if(h < -0.5)
		{
			goingPosX = leftPos;
			startExit = StartExitEnum.start;
			startButton.selectedFlag = true;
		}
		else
		{
			startButton.selectedFlag = false;
		}
		if(h <= 0.5 && h >= -0.5)
		{
			goingPosX = 0;
			startExit = StartExitEnum.none;
		}
		nowPos.x = Mathf.Lerp(nowPos.x, goingPosX, 1 / (speed * 1000 * Time.deltaTime));

		if(Input.GetKeyDown(ConstClass.shootkey))
		{
			switch(startExit)
			{
				case StartExitEnum.start:
					StartCoroutine(SelectStart());
					break;
				case StartExitEnum.exit:
					Debug.Log("exit");
#if UNITY_EDITOR
					UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();
#endif
					break;
				case StartExitEnum.none:
					Debug.Log("none");
					break;
			}
		}
	}
	private void FixedUpdate()
	{
		transform.position = nowPos;
	}
	IEnumerator SelectStart()
	{
		Debug.Log("start");
		audioSource.PlayOneShot(goatCrySound);
		yield return StartCoroutine(flushController.FadeOut());
		SceneManager.LoadScene(1);
	}
}
