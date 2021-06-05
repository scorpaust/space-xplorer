using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRandom : MonoBehaviour
{
    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private float minY, maxY;

    [SerializeField]
    private float moveSpeed = 8f;

    private Vector3 targetPos;

	private void Start()
	{
        SetTargetPosition();
	}

	private void Update()
	{
        Move();
	}

	private void SetTargetPosition()
	{
        targetPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
	}

    private void Move()
	{
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            SetTargetPosition();

	}
}
