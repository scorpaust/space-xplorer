﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 3f;

    public float minDamage = 10f;

    public float maxDamage = 30f;

    private float projectileDamage;

    [SerializeField]
    private AudioClip spawnSound;

    [SerializeField]
    private AudioClip destroySound;

    [SerializeField]
    private GameObject boomEffect;

	private void OnEnable()
	{
        if (spawnSound)
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 6f, 0f));
    }

	private void Start()
	{
        projectileDamage = (int)Random.Range(minDamage, maxDamage);
	}

	private void Update()
	{
        transform.Translate(0f, speed * Time.deltaTime, 0f);
	}

}
