using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPositionEnum
{
    Up,
    Down,
    Left,
    Right
}

public class ShipFXSpawner : MonoBehaviour
{

    public SpawnPositionEnum spawnPosEnum;

    [SerializeField]
    private GameObject[] ships;

    [SerializeField]
    private float minSpawnTime = 5f, maxSpawnTime = 10f;

    [SerializeField]
    private float minX = -25f, maxX = 25f;

    [SerializeField]
    private float minY = -27f, maxY = 27f;

    private float spawnTimer;

    private bool shipSpawned;

    private Vector3 spawnPos;

    private List<GameObject> spawnedShips = new List<GameObject>();

	private void Start()
	{
        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

	private void Update()
	{
        if (Time.time > spawnTimer)
            SpawnShip();
	}

	private void SpawnShip()
	{
        shipSpawned = false;

        for (int i = 0; i < spawnedShips.Count; i++)
		{
            if (!spawnedShips[i].activeInHierarchy)
			{
                ActivateShip(spawnedShips[i], false);

                shipSpawned = true;
            }
                
		}

        if (!shipSpawned)
		{
            GameObject newShip = Instantiate(ships[Random.Range(0, ships.Length)]);

            ActivateShip(newShip, true);
		}

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
	}

    private void ActivateShip(GameObject ship, bool addToList)
	{
        ship.SetActive(true);

        ship.transform.SetParent(transform);

        if (spawnPosEnum == SpawnPositionEnum.Up)
		{
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

            ship.GetComponent<SpaceshipFXMovement>().SetMovement(true, false, true);

            ship.transform.position = spawnPos;
		}
        else if (spawnPosEnum == SpawnPositionEnum.Down)
		{
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);

            ship.GetComponent<SpaceshipFXMovement>().SetMovement(true, false, false);

            ship.transform.position = spawnPos;
        }
        else if (spawnPosEnum == SpawnPositionEnum.Left)
        {
            spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);

            ship.GetComponent<SpaceshipFXMovement>().SetMovement(false, true, false);

            ship.transform.position = spawnPos;
        }
        else if (spawnPosEnum == SpawnPositionEnum.Right)
        {
            spawnPos = new Vector3(transform.position.x, Random.Range(minY, maxY), 0f);

            ship.GetComponent<SpaceshipFXMovement>().SetMovement(false, true, true);

            ship.transform.position = spawnPos;
        }

        if (addToList)
            spawnedShips.Add(ship);
    }

}
