using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{

    [SerializeField]
    private float speed = 600f;

    private Rigidbody2D myBody;


	private void Awake()
	{
        myBody = GetComponent<Rigidbody2D>();
	}


	// Start is called before the first frame update
	void Start()
    {
        
    }

	private void FixedUpdate()
	{
		HandleMovement();
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	private void HandleMovement()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			myBody.AddForce(transform.up * speed);

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			myBody.AddForce(-transform.up * speed);

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			myBody.AddForce(transform.right * speed);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			myBody.AddForce(-transform.right * speed);
	}
}
