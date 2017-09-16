using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 5;
	public bool facingRight = true;
	private Rigidbody2D playerRigi;
	private SpriteRenderer playerSR;
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private bool doubleJump = false;
	public Animator playerAnim;
	public bool isThrowing;
	public GameObject throwingSand;
	public bool hasAnkh = false;

	void Start () {
		playerRigi = GetComponent<Rigidbody2D> ();
		playerSR = GetComponent<SpriteRenderer> ();
	}
	
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		playerAnim.SetBool ("Grounded", grounded);

		if (grounded)
			doubleJump = false;

		float move = Input.GetAxis ("Horizontal");

		playerAnim.SetFloat ("Speed", Mathf.Abs (move));

		playerRigi.velocity = new Vector2 (move * maxSpeed, playerRigi.velocity.y);



		if (Input.GetKeyDown (KeyCode.Space) && !isThrowing) {
			
			if (hasAnkh) {
				isThrowing = true;
				Throw ();
			}
		}

		if (move > 0 && !facingRight) {
			facingRight = !facingRight;
			playerSR.flipX = false;
		}
		else if (move < 0 && facingRight){
			playerSR.flipX = true;
			facingRight = !facingRight;
		}
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.W) && (grounded ||!doubleJump )) {
			playerRigi.AddForce (new Vector2(0, 12.5f), ForceMode2D.Impulse);

			if (!doubleJump && !grounded)
				doubleJump = true;
		}
			
	}
	void Throw(){
		playerAnim.SetTrigger ("Throwing");
		GameObject flyingSand = (GameObject)Instantiate (throwingSand, transform.position, Quaternion.identity);
		if (facingRight)
			flyingSand.GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x, 2) * 1;
		else {
			flyingSand.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-transform.localScale.x, 2) * 1;
			flyingSand.GetComponent<SpriteRenderer> ().flipX = true;
		}
	
		isThrowing = false;
	}
}
