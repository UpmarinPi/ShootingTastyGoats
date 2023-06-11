using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;
using UnityEngine.SceneManagement;

public class ShowScore : MonoBehaviour
{
	[SerializeField]List<GameObject> showScores = new List<GameObject>();
	[SerializeField] float waitTime;
	void Start()
	{
		for(int i = 0; i < showScores.Count; i++)
		{
			showScores[i].SetActive(false);
		}
		StartCoroutine(junbanActive());
	}

	private void Update()
	{
		if(Input.GetKey(ConstClass.startkey))
		{
			SceneManager.LoadScene("SampleScene");
		}
		else if(Input.GetKey(ConstClass.selectkey))
		{
			SceneManager.LoadScene("Title");
		}
	}

	IEnumerator junbanActive()
	{
		Debug.Log("hi");
		for(int i = 0; i < showScores.Count; i++)
		{
			yield return new WaitForSeconds(waitTime);
			showScores[i].SetActive(true);
		}
	}
}
