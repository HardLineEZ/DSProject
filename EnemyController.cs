using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	GameObject player;
	public int timer = 0;
	public int neededTimeToOneSide = 60;
	private bool needToPerformReturn = false;
	private float minFollowDistance = 1f;
	private float maxFollowDistance = 4f;
	private bool wasTurned = false;
	public float jumpPower = 1.7f;
	float toInstantiateX;
	float toInstantiateY;
	//private float startingPlayerYAxis;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		toInstantiateX = transform.position.x;
		toInstantiateY = transform.position.y;
		//startingPlayerYAxis = player.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if ( (transform.position.x - player.transform.position.x) <= minFollowDistance) {
			if ( (transform.position.x - player.transform.position.x) <= maxFollowDistance) {
				FollowPlayer ();
			}
		}
		else
		if (!needToPerformReturn) {
			Move ();
		}
		else
		if (needToPerformReturn) {
			Return ();
		}
		if (transform.position.y <= -5f)
		{
			transform.position = new Vector2 (toInstantiateX, toInstantiateY);
			timer = 2;
		}

	}
	void Move()
	{
		if (wasTurned) {
			transform.eulerAngles = new Vector2 (0, 360);
		}
		timer += 1;
		transform.position = new Vector2 (transform.position.x  + Time.smoothDeltaTime, transform.position.y);
		if (timer == neededTimeToOneSide) {
			needToPerformReturn = true;
		}
	}
	void Return()
	{
		transform.eulerAngles = new Vector2 (0, 180);
		wasTurned = true;
		timer -= 1;
		transform.position = new Vector2 (transform.position.x   - Time.smoothDeltaTime, transform.position.y);
		if (timer == 0) {
			needToPerformReturn = false;
		}
	}
	void FollowPlayer()
	{
		if (player.transform.position.x <= transform.position.x) {
			transform.position = new Vector2 (transform.position.x - Time.smoothDeltaTime, transform.position.y);
		}
		if (player.transform.position.x > transform.position.x) {
			transform.position = new Vector2 (transform.position.x + Time.smoothDeltaTime, transform.position.y);
		}
		/*if ((player.transform.position.x > transform.position.x) && (player.transform.position.y > startingPlayerYAxis)) {
			transform.position = new Vector2 (transform.position.x + Time.smoothDeltaTime, transform.position.y * jumpPower);
		}					//this should allow enemy to jump, but it's not working, LOL
		if ((player.transform.position.x <= transform.position.x) && (player.transform.position.y > startingPlayerYAxis)) {
			transform.position = new Vector2 (transform.position.x - Time.smoothDeltaTime, transform.position.y * jumpPower);
		}*/
	}

}
