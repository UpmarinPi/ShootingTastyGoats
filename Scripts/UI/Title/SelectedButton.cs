using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedButton : MonoBehaviour
{
	[SerializeField] float hideSize;
	[SerializeField] float showSize;
	[SerializeField] float speed;
	public bool selectedFlag;
	RectTransform rectTransform;
	float nowSize;
	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		nowSize = hideSize;
	}
	private void Update()
	{
		if(selectedFlag)
		{
			nowSize = Mathf.Lerp(nowSize, showSize, 1 / (speed * 1000 * Time.deltaTime));
		}
		else
		{
			nowSize = Mathf.Lerp(nowSize, hideSize, 1 / (speed * 1000 * Time.deltaTime));
		}
	}
	private void FixedUpdate()
	{
		rectTransform.localScale = new Vector2(nowSize, nowSize);
	}
}
