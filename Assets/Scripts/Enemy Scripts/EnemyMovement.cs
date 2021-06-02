using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private bool moveOnX, moveOnY;

    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private float horizontalMovementTreshold = 8f;

    [SerializeField]
    private float verticalMovementTreshold = 6f;

    private float minX, maxX;

    private float minY, maxY;

    private Vector3 tempMovementHorizontal, tempMovementVertical;

    private bool moveLeft;

    private bool moveUp = false;

	private void Start()
	{
        minX = transform.position.x - horizontalMovementTreshold;
        maxX = transform.position.x + horizontalMovementTreshold;

        maxY = transform.position.y;
        minY = transform.position.y - verticalMovementTreshold;

        if (Random.Range(0, 2) > 0)
            moveLeft = true;
	}

	private void Update()
	{
        HandleEnemyMovementHorizontal();
        HandleEnemyMovementVertical();
	}

	private void HandleEnemyMovementHorizontal()
	{
        if (!moveOnX)
            return;

        if (moveLeft)
		{
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x < minX)
                moveLeft = false;
		}
        else
		{
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x > maxX)
                moveLeft = true;
        }
	}

    private void HandleEnemyMovementVertical()
	{
        if (!moveOnY)
            return;

        if (moveUp)
		{
            tempMovementVertical = transform.position;
            tempMovementVertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y > maxY)
                moveUp = false;
		}
        else
		{
            tempMovementVertical = transform.position;
            tempMovementVertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;

            if (tempMovementVertical.y < minY)
                moveUp = true;
        }
	}
}
