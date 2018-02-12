using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

	public TextMeshProUGUI CounterText;
	public GameObject BlackImage;

	private void Start()
	{
		StartCoroutine(StartMatch());
	}

	private IEnumerator StartMatch()
	{
		yield return new WaitForSeconds(1f);
		CounterText.text = 2.ToString();
		yield return new WaitForSeconds(1f);
		CounterText.text = 1.ToString();
		yield return new WaitForSeconds(1f);
		BlackImage.SetActive(false);
		CounterText.gameObject.SetActive(false);
		CarController.started = true;
	}

}
