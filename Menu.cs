using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour 
{
	public int window;
	// Use this for initialization
	void Start () 
	{
		window = 1;
	}
	
	// Update is called once per frame

	public void OnGUI ()
	{
		GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
		if(window == 1) 
		{ 
			if(GUI.Button (new Rect (10,30,180,30), "Play")) 
			{ 
				window = 2;   
			} 
			if(GUI.Button (new Rect (10,70,180,30), "Settings")) 
			{ 
				window = 3; 
			} 
			if(GUI.Button (new Rect (10,110,180,30), "About")) 
			{ 
				window = 4; 
			} 
			if(GUI.Button (new Rect (10,150,180,30), "Exit")) 
			{ 
				window = 5; 
			} 
		} 
		if(window == 2) 
		{ 
			GUI.Label(new Rect(50, 10, 180, 30), "Choose level");   
			if(GUI.Button (new Rect (10,40,180,30), "Level 1")) 
			{ 
				Debug.Log("Level 1 loaded"); 
				SceneManager.LoadScene (0);
			} 
			if(GUI.Button (new Rect (10,80,180,30), "Level 2")) 
			{ 
				Debug.Log("Level 2 loaded"); 
				SceneManager.LoadScene (1);
			} 
			if(GUI.Button (new Rect (10,120,180,30), "Level 3")) 
			{ 
				Debug.Log("Level 3 loaded"); 
			} 
			if(GUI.Button (new Rect (10,160,180,30), "Back")) 
			{ 
				window = 1; 
			} 
		} 
		if(window == 3) 
		{ 
			GUI.Label(new Rect(50, 10, 180, 30), "Settings");   
			if(GUI.Button (new Rect (10,40,180,30), "Game")) 
			{ 
			} 
			if(GUI.Button (new Rect (10,80,180,30), "Audio")) 
			{ 
			} 
			if(GUI.Button (new Rect (10,120,180,30), "Video")) 
			{ 
			} 
			if(GUI.Button (new Rect (10,160,180,30), "Back")) 
			{ 
				window = 1; 
			}   
			if(window == 5) 
			{ 
				GUI.Label(new Rect(50, 10, 180, 30), "Вы уже выходите?");   
				if(GUI.Button (new Rect (10,40,180,30), "Да")) 
				{ 
					Application.Quit(); 
				} 
				if(GUI.Button (new Rect (10,80,180,30), "Нет")) 
				{ 
					window = 1; 
				} 
			} 
		} 
		GUI.EndGroup (); 
	}

}
