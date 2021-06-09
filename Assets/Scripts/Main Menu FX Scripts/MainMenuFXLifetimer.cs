using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFXLifetimer : MonoBehaviour
{
	[SerializeField]
	private float timer = 5f;

	private void OnEnable()
	{
		Invoke("DeactivateGameObject", timer);
	}

	private void DeactivateGameObject()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		CancelInvoke("DeactivateGameObject");
	}
}
