using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
    private float moveVelocity;
	public float jumpHeight;
    private bool moveRight = true;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;
    

    private Animator anim;
	public Transform firePoint;
	public GameObject ninjaStar;

	void Start () {
        anim = GetComponent<Animator>(); 
    }

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update () {

        bool jumping = false;
        bool falling = false;

        anim.SetBool("Grounded", grounded);

        if (grounded)
        {
            jumping = false;
            falling = false;
        }
        
		if (grounded && (Input.GetKeyDown(KeyCode.UpArrow))) {
			Jump ();
		}

        moveVelocity = 0f;
        Vector3 currentScale = transform.localScale;

        if ((Input.GetKeyDown(KeyCode.LeftArrow) && moveRight) || (Input.GetKeyDown(KeyCode.RightArrow) && !moveRight))
        {
            currentScale.x = -currentScale.x;
            transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z);
        }

        if (Input.GetKey (KeyCode.RightArrow)) {
            moveVelocity = moveSpeed;
            moveRight = true;
        }

		if (Input.GetKey (KeyCode.LeftArrow)) {
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
		
		if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
		}

    }

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
