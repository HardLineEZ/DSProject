using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStats: MonoBehaviour {
	public float playerDamage;
	float playerHealth = 100f;
	public float currentHealth;
	// Use this for initialization
	void Start () {
		playerDamage = 50;
		currentHealth = playerHealth;
	}

	void Update () {

		if (currentHealth <= 0) {
			DieAndRespawn ();
		}
	}
	void OnCollisionEnter2D(Collision2D collisionObject)
	{
		if (collisionObject.gameObject.tag == "Enemy2")
		{
			currentHealth -= 10;
		}
		// currentHealthText.text = "HP " + currentHealth;
	}
	void DieAndRespawn ()
	{
		currentHealth = playerHealth;
	}
}

