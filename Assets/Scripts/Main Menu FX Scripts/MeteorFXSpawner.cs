using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

	private List<GameObject> spawnedMeteors = new List<GameObject>();

    [SerializeField]
    private float minSpawnTime = 2f, maxSpawnTime = 5f;

	[SerializeField]
	private float minX, maxX;

	[SerializeField]
	private bool moveDown;

	private float spawnTimer;

	private Vector3 spawnPos;

	private int spawnNumber;

	private int activatedMeteors;

	private void Start()
	{
		spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);

		SpawnInitialNumberOfMeteors(40);
	}

	private void Update()
	{
		if (Time.time > spawnTimer)
			SpawnMeteorsFromPool();
	}

    private void SpawnMeteor()
	{
		spawnNumber = Random.Range(1, 6);

		for (int i = 0; i < spawnNumber; i++)
		{
			spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

			GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPos, Quaternion.identity);

			if (moveDown)
				newMeteor.GetComponent<MeteorFXMovement>().moveDown = true;

			newMeteor.transform.SetParent(transform);
		}

		spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
	}

	private void SpawnInitialNumberOfMeteors(int spawnNum)
	{
		for (int i = 0; i < spawnNum; i++)
		{
			GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)]);

			newMeteor.transform.SetParent(transform);

			newMeteor.SetActive(false);

			spawnedMeteors.Add(newMeteor);
		}
	}

	private void SpawnMeteorsFromPool()
	{
		spawnNumber = Random.Range(1, 6);

		activatedMeteors = 0;

		for (int i = 0; i < spawnedMeteors.Count; i++)
		{
			if (!spawnedMeteors[i].activeInHierarchy)
			{
				spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

				spawnedMeteors[i].SetActive(true);

				spawnedMeteors[i].transform.position = spawnPos;

				GameObject newMeteor = Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPos, Quaternion.identity);

				if (moveDown)
					spawnedMeteors[i].GetComponent<MeteorFXMovement>().moveDown = true;

				activatedMeteors++;

				if (activatedMeteors == spawnNumber)
					break;
			}
		}

		spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
	}
}
