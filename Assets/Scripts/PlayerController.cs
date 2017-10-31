using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;

	void Start () {
		
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update () {
		if (grounded) {
			doubleJumped = false;
		}

		if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
			Jump ();
		}

		if (!doubleJumped && !grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
			Jump ();
			doubleJumped = true;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
