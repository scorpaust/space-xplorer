﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private int minSpawnNumber = 1, maxSpawnNumber = 5;

    private float minSpawnInterval = 4f, maxSpawnInterval = 10f;

    private int randSpawnNumber;

    private Vector3 randSpawnPos;

	private void Start()
	{
        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

	private void SpawnMeteors()
	{
        randSpawnNumber = Random.Range(minSpawnNumber, maxSpawnNumber);

        for (int i = 0; i < randSpawnNumber; i++)
		{
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
		}

        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}
