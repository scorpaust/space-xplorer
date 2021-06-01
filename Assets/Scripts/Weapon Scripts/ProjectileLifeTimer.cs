using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTimer : MonoBehaviour
{
    public float timer = 3f;

	private void OnEnable()
	{
		Invoke("DeactivateProjectile", timer);
	}

	private void DeactivateProjectile()
	{
		if (gameObject.activeInHierarchy)
			gameObject.SetActive(false);
	}
}
