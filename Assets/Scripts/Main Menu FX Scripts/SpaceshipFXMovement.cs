using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFXMovement : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 5f, maxSpeed = 10f;

    private float moveSpeed;

	private Vector3 tempPos;

	private bool moveVertical, moveHorizontal;

	private void Update()
	{
		MoveVertical();

		MoveHorizontal();
	}

	private void MoveVertical()
	{

		if (!moveVertical)
			return;

		tempPos = transform.position;

		tempPos.y += moveSpeed * Time.deltaTime;

		transform.position = tempPos;
	}

	private void MoveHorizontal()
	{

		if (!moveHorizontal)
			return;

		tempPos = transform.position;

		tempPos.x += moveSpeed * Time.deltaTime;

		transform.position = tempPos;
	}

	public void SetMovement(bool moveVer, bool moveHor, bool moveNegative)
	{
		moveVertical = moveVer;

		moveHorizontal = moveHor;

		moveSpeed = Random.Range(minSpeed, maxSpeed);

		if (moveNegative)
			moveSpeed *= -1f;

		if (moveVertical && moveNegative)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 180f);
		}

		if (moveHorizontal && moveNegative)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, 90f);
		}

		if (moveHorizontal && !moveNegative)
		{
			transform.rotation = Quaternion.Euler(0f, 0f, -90f);
		}

		if (moveVertical && !moveNegative)
		{

		}
	}
}
