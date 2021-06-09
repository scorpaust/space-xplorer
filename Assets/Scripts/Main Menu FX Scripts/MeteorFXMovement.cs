using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXMovement : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 5f, maxSpeed = 10f;

    [SerializeField]
    private float minRotateSpeed = 8f, maxRotateSpeed = 20f;

    [HideInInspector]
    public bool moveDown;

    private float speedY, speedX;

    private float rotationSpeed;

    private float zRotation;

    private bool moveOnX, moveOnY = true;

    private Vector3 tempPos;

	private void Awake()
	{
        speedY = Random.Range(minSpeed, maxSpeed);
        
        speedX = speedY;

        rotationSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);

        if (Random.Range(0, 2) > 0)
            moveOnX = true;

        if (Random.Range(0, 2) > 0)
            speedX *= -1;

        if (Random.Range(0, 2) > 0)
            rotationSpeed *= -1;

    }

	private void Start()
	{
        if (moveDown)
            speedY *= -1f;
	}

	private void Update()
	{
        HandleMovement();

        HandleRotation();
	}

	private void HandleMovement()
	{
        if (!moveOnY)
            return;

        tempPos = transform.position;

        tempPos.y += speedY * Time.deltaTime;

        transform.position = tempPos;

        if (!moveOnX)
            return;

        tempPos = transform.position;

        tempPos.x += speedX * Time.deltaTime;

        transform.position = tempPos;
    }

    private void HandleRotation()
	{
        zRotation += rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
	}
}
