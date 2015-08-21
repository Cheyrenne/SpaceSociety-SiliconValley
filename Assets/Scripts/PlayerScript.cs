using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public int speed = 1;
	public int jump = 160;
	
	private Rigidbody2D player;
	private bool colliding = false;

	void Start() {
		player = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.D)) {
			player.AddForce(Vector2.right * speed);
		}
		if (Input.GetKey (KeyCode.A)) {
			player.AddForce(Vector2.left * speed);
		} 
		if (Input.GetKeyDown (KeyCode.Space) && 
		    colliding == true) {
			player.AddForce(Vector2.up * jump);
		}
	}
	
	void FixedUpdate()
	{
		// 3 - Retrieve axis information
		//float inputX = Input.GetAxisRaw("Horizontal");
		//float inputY = Input.GetAxisRaw("Vertical");

		
		// 4 - Movement per direction
		//movement = new Vector2(move_left, move_right);
		// 5 - Move the game object

		//move_left = 0;
		//move_right = 0;
	}

	void OnCollisionStay2D() {
		colliding = true;
	}

	void OnCollisionExit2D() {
		colliding = false;
	}

	public bool isGrounded() {
		if (player.velocity.y == 0){
			return true;
		}
		else
			return false;
	}
	
}

	