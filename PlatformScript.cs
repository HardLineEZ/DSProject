using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {
	public Vector2 speed = new Vector2(0, 3);
	public Vector2 direction = new Vector2(0, 1);
	public float t = 0.2f;
	private Vector2 movement;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(ChangeDirection());
	}

	// Update is called once per frame
	void Update () 
	{
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	IEnumerator ChangeDirection ()
	{
		yield return new WaitForSecondsRealtime(t);
		direction.y *= -1;
		StartCoroutine(ChangeDirection());
	}

	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
