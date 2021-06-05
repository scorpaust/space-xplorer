using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementInPoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] movementPoints;

    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private bool moveRandomly;

    private int currentMoveIndex;

    private Vector3 targetPos;

	private void Start()
	{
        SetTargetPosition();
	}

	private void Update()
	{
        Move();
	}

	private void SelectRandomPosition()
	{
        while (movementPoints[currentMoveIndex].position == targetPos)
            currentMoveIndex = Random.Range(0, movementPoints.Length);

        targetPos = movementPoints[currentMoveIndex].position;
	}

    private void SelectPointToPointPosition()
	{
        if (currentMoveIndex == movementPoints.Length)
            currentMoveIndex = 0;

        targetPos = movementPoints[currentMoveIndex].position;

        currentMoveIndex++;
    }

    private void SetTargetPosition()
	{
        if (moveRandomly)
            SelectRandomPosition();
        else
            SelectPointToPointPosition();
	}

    private void Move()
	{
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
		{
            SetTargetPosition();
		}
	}

}
