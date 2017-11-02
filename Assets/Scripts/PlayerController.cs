using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update () {
		/*if (grounded) {
			doubleJumped = false;
		}*/

        anim.SetBool("Grounded", grounded);
        
		if (grounded && ((Input.GetAxis("Jump") > 0) || Input.GetKeyDown(KeyCode.UpArrow))) {
			Jump ();
		}

		/*if (!doubleJumped && !grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
			Jump ();
			doubleJumped = true;
		}*/

        moveVelocity = 0f;

		if (Input.GetKey (KeyCode.RightArrow)) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
		}

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        
    }

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
