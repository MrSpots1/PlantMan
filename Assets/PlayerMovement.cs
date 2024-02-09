using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	private float horizontalMove = 0f;
	public bool _jump = false;
	public bool _crouch = false;
	public bool _glide = false;
	public bool _dash = false;
	public bool _initiateWall = false;
	// Update is called once per frame
	void Update ()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			if (controller.m_LeftWall == false && controller.m_RightWall == false)
			{
				_jump = true;
			} 
			else 
			{
			_initiateWall = true;
			}
		}
		
		if (Input.GetButtonDown("Glide") /*&& ableGlide*/)
		{
			_glide = true;
		}
		else if (Input.GetButtonUp("Glide"))
		{
			_glide = false;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			_crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			_crouch = false;
		}

		if (Input.GetButtonDown("Dash"))
		{
			_dash = true;
			
		}
		else if (Input.GetButtonUp("Dash"))
		{
			_dash = false;
		}
 
		 
		//Debug.Log($", controller.Glide: {controller.Glide}");
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, _crouch, _jump, _glide, _dash, _initiateWall);
		_jump = false;
		_initiateWall = false;
	}
}