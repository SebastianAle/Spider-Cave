﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{


	public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;

	private bool grounded = true;

	private Rigidbody2D myBody;
	private Animator anim;


	void Awake()
	{
		InitialzeVariables ();
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		PlayerWalkKeyboard ();
	}

	void InitialzeVariables()
	{
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void PlayerWalkKeyboard()
	{
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) 
		{
			if (vel < maxVelocity) 
			{
				if (grounded) 
				{
					forceX = moveForce;
				} else 
				{
					forceX = moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool ("Walk", true);
		} 
		else if (h < 0) 
		{
			if (vel < maxVelocity) 
			{
				if (grounded) 
				{
					forceX = -moveForce;
				} else 
				{
					forceX = -moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			anim.SetBool ("Walk", true);
		} 
		else if (h == 0) 
		{
			anim.SetBool ("Walk", false);
		}

		if (Input.GetKey (KeyCode.Space)) 
		{
			if (grounded == true) 
			{
				grounded = false;
				forceY = jumpForce;
			}
		}

		myBody.AddForce (new Vector2 (forceX, forceY));
	}

	public void BouncePlayerWithBouncy(float force)
	{
		if (grounded) 
		{
			grounded = false;
			myBody.AddForce(new Vector2 (0, force));
		}
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Ground") 
		{
			grounded = true;
		}
	}


























}
