using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	RectTransform rectTransform;
	[SerializeField] float startSize;
	[SerializeField] int speed;
	float nowSize;
	float originSize = 1.12f;

	[SerializeField] int startTime;
	float startTimer;
	void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		nowSize = startSize;

	}

	// Update is called once per frame
	void Update()
	{
		if(startTimer >= startTime / 100.0f)
		{
			nowSize = Mathf.Lerp(nowSize, originSize, 1 / (speed * 1000 * Time.deltaTime));
		}
		else
		{
			startTimer += Time.deltaTime;

		}
	}
	private void FixedUpdate()
	{
		rectTransform.localScale = new Vector2(nowSize, nowSize);
	}

}
