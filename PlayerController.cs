using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
	public  float speed;
	private bool FacedRight = true;
	private bool isGrounded = true;
	public float jumpPower;
	private Animator anim;
	public float timer = 0;
	int currentScene;
	// Animator controlAnimation;
	void Start ()
	{
		anim = GetComponent<Animator>();
		currentScene = SceneManager.GetActiveScene ().buildIndex;
	}

	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		//anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis ("Horizontal")))
		anim.SetBool ("Ground", isGrounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		var movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
		transform.position += movement * speed * Time.smoothDeltaTime;
		if (Input.GetKey (KeyCode.RightArrow) && (!FacedRight))
		{
			RightFlip ();
		}
		if (Input.GetKey (KeyCode.LeftArrow) && (FacedRight)) 
		{
			LeftFlip ();
		}
		if ((Input.GetKey (KeyCode.UpArrow)) && (isGrounded))
		{
			Jumping ();
		}
		if (transform.position.y <= -5f)
		{
			SceneManager.LoadScene (currentScene); 	//if player falls, he dies and we reload a scene
		}
	}

	void LeftFlip()
	{
		transform.eulerAngles = new Vector2 (0, 180);
		FacedRight = false;
	}
	void RightFlip()
	{
		transform.eulerAngles = new Vector2 (0, 360);
		FacedRight = true;
	}
	void Jumping(){						//Jumping
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
	}
	void OnCollisionStay2D(Collision2D obj) //Checking collision with ground to prepare for jump
	{
		if (obj.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
}
