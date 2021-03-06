﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

	public float moveSpeed;
    private float moveVelocity;
	public float jumpHeight;
    public bool moveRight = true;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;
    

    private Animator anim;
	public Transform firePoint2;
	public GameObject ninjaStar2;

	public KeyCode up;
	public KeyCode right;
	public KeyCode left;
	public KeyCode fire;
	
	void Start ()
	{
        anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update () {

        bool jumping = false;
        bool falling = false;

        anim.SetBool("Grounded", grounded);

        if (grounded){
            jumping = false;
            falling = false;
        }
        
		if (grounded && (Input.GetKeyDown(up))) {
			Jump ();
		}

        moveVelocity = 0f;
        Vector3 currentScale = transform.localScale;

        if ((Input.GetKeyDown(left) && moveRight) || (Input.GetKeyDown(right) && !moveRight))
        {
            currentScale.x = -currentScale.x;
            transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z);
        }

        if (Input.GetKey (right)) {
            moveVelocity = moveSpeed;
            moveRight = true;
        }

		if (Input.GetKey (left)) {
            moveVelocity = -moveSpeed;
            moveRight = false;
        }
 
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if(!grounded && GetComponent<Rigidbody2D>().velocity.y > 0.3)
        {
            jumping = true;
            falling = false;
        }
        else if (!grounded && GetComponent<Rigidbody2D>().velocity.y < -0.3)
        {
            jumping = false;
            falling = true;
        }

        anim.SetBool("isJumping", jumping);
        anim.SetBool("isFalling", falling);
		
		if(Input.GetKeyDown(fire)){
			Instantiate(ninjaStar2, firePoint2.position, firePoint2.rotation);
		}

    }

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
