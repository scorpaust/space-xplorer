using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Health,
    Blaster1,
    Blaster2,
    Missile,
    Rocket
}

public class Collectable : MonoBehaviour
{
    public CollectableType type;

    [HideInInspector]
    public float healthValue;

    [SerializeField]
    private float moveSpeed = 5f;

    private Vector3 tempPos;

    private float minHealth = 10f, maxHealth = 30f;

	private void Start()
	{
        healthValue = Random.Range(minHealth, maxHealth);
	}

	private void Update()
	{
        tempPos = transform.position;

        tempPos.y -= moveSpeed * Time.deltaTime;

        transform.position = tempPos;
	}

	private void OnDisable()
	{
        SoundManager.instance.PlayPickupSound();
	}
}
