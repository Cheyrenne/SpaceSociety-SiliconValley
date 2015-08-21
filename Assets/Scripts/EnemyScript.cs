using UnityEngine;
using System.Collections;
using System;

public class EnemyScript : MonoBehaviour {

	struct Timer {
		public void Pause(int seconds) {
			float elapsed = 0;
			while ((int)elapsed < seconds) {
				elapsed += Time.deltaTime;
			}
			return;
		}
	}

	public int speed = 5; // speed
	public int roam = 300; // max distance enemy will walk
	public float chase_distance = 5; // distance at or below enemy will chase
	public int damage = 25;

	private int walked = 0; // initial distance walked
	private bool dir = true; // true - right, false - left
	private float dist = 0;
	private GameObject player; 
	private Rigidbody2D player_body, enemy_body;

	// Use this for initialization
	void Start () {
		// get a reference to the Player Object
		player = GameObject.FindGameObjectWithTag ("Player");
		player_body = player.GetComponent<Rigidbody2D> ();
		enemy_body = GetComponent<Rigidbody2D> ();
		//if (player != null)
			//Console.WriteLine ("Player found");
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Physics updates
	void FixedUpdate() {
		// Get distance from enemy to Player along x-axis
		// STUB - more efficient way?
		if (player != null)
			dist = Mathf.Abs (this.player_body.position.x - this.enemy_body.position.x);
		else
			dist = chase_distance + 1;
		//Console.WriteLine ("Distance between Player and enemy: {0}\nPlayer x: {1}\n Enemy x: {2}", dist, this.player_body.position.x,
		//this.enemy_body.position.x);
		if (dist <= this.chase_distance) {
			Chase ();
		} 
		else { 
			RandomWalk ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag =="Player") {
			// bounce player back
			coll.rigidbody.AddForce(coll.relativeVelocity, ForceMode2D.Impulse);

			// bounce enemy back with scaled force?
		}
	}

	void RandomWalk() {
		// move right
		if (walked < roam && dir == true) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed);
			walked += speed;
		}
		// move left
		else if (walked < roam && dir == false) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.left * speed);
			walked += speed;
		}
		// Reached maximum distance
		else {
			if (dir) 
				dir = false; // change direction to left
			else
				dir = true; // change direction to right
			walked = 0; // reset walked distance 

			// Pause for a few seconds before moving in opposite direction
		}
	}

	void Chase() {
		// player is to the right of the enemy
		if (this.player_body.position.x > this.enemy_body.position.x) {
			this.enemy_body.AddForce (Vector2.right * this.speed);
		}
		// player is to the left of the enemy
		else {
			this.enemy_body.AddForce (Vector2.left * this.speed);
		}

	}
	
};

