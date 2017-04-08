using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthbar : MonoBehaviour {
	public float startingEnemyHealth = 100;
	public float currentEnemyHealth;
	int timer = 5;
	float toInstantiateX;
	float toInstantiateY;
	PlayerStats playerDamage;
	// Use this for initialization
	void Start () {
		currentEnemyHealth = startingEnemyHealth;
		toInstantiateX = transform.position.x;
		toInstantiateY = transform.position.y;
		playerDamage = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentEnemyHealth <= 0) {
			StartCoroutine (countdownEnemyRespawn ());
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			currentEnemyHealth -= (int)playerDamage.playerDamage;
		}
	}
	IEnumerator countdownEnemyRespawn()
	{
		yield return new WaitForSecondsRealtime (timer);
		transform.position = new Vector2 (toInstantiateX, toInstantiateY);
		currentEnemyHealth = startingEnemyHealth;
		timer = 2;
	}
}
