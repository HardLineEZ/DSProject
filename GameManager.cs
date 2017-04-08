using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	Animation myAnimation;
	int currentScene;
	// Use this for initialization
	void Start ()
	{
		//doorAnim = GameObject.FindGameObjectWithTag ("Door").GetComponent<Animator> ();
		currentScene = SceneManager.GetActiveScene ().buildIndex;
	}

	// Update is called once per frame
	void Update () 
	{

	}
	void OnCollisionStay2D(Collision2D diffObject)
	{
		if (diffObject.gameObject.tag == "DoorToNextLvl") {
			if (Input.GetKey (KeyCode.E)) {
				Debug.Log (currentScene);
				SceneManager.LoadScene (currentScene + 1);
			}
		}
		if (diffObject.gameObject.tag == "DoorToPreviousLvl") {
			if (Input.GetKey(KeyCode.E)){
				SceneManager.LoadScene(currentScene - 1);
			}
		}
	}
	void OnCollisionExit2D(Collision2D diffObject)
	{
		if (diffObject.gameObject.tag == "Doorto") {
		}
	}
	/*IEnumerator PlayDoorAnimation(Animator doorAnimation) 	{ 		doorAnimation.StartPlayback (); 		//var n = WaitForSeconds (5); 		return null; 	} */
}

