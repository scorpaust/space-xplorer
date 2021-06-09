using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private float spawnWaitTime = 2f;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

	private void Awake()
	{
        if (instance == null)
            instance = this;
	}

	private void Start()
	{
        StartCoroutine(_SpawnWave(spawnWaitTime));
	}

	private void SpawnNewWaveOfEnemies()
	{
        if (spawnedEnemies.Count > 0)
            return;

        for (int i = 0; i < spawnPoints.Length; i++)
		{
            int randIndex = Random.Range(0, enemies.Length);

            GameObject newEnemy = Instantiate(enemies[randIndex], spawnPoints[i].position, Quaternion.identity);

            spawnedEnemies.Add(newEnemy);
		}

        GameplayUIController.instance.SetInfo(1);
	}

    IEnumerator _SpawnWave(float waitTime)
	{
        yield return new WaitForSeconds(waitTime);
        SpawnNewWaveOfEnemies();
	}

    public void CheckToSpawnNewWave(GameObject shipToRemove)
	{
        spawnedEnemies.Remove(shipToRemove);

        if (spawnedEnemies.Count == 0)
            StartCoroutine(_SpawnWave(spawnWaitTime));
	}
}
