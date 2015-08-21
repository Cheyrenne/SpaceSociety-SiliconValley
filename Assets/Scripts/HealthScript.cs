using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public bool invincible = false;

	private int health = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Damage(int damage) {
		health -= damage;
		if (health <= 0 && invincible == false)
			Destroy (gameObject);
	}

	void GainHealth(int hp) {
		health += hp;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy")) {
			EnemyScript enemy = coll.gameObject.GetComponent<EnemyScript>();
			Damage(enemy.damage);
		}
		/*
		if (coll.collider.CompareTag("Health")) {
			HealthItem item = coll.gameObject.GetComponent<HealthItem> ();
			GainHealth(item.health);
		}
		*/
	}
}
