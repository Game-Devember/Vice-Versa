using UnityEngine;
using System.Collections;

public class help_back : MonoBehaviour {
	
	void Update()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.LoadLevel("main_menu");
				return;
			}
			//Time.timeScale = 0;
		}
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.LoadLevel("main_menu");
				return;
			}
			//Time.timeScale = 0;
		}
	}
	void OnTouchDown()
	{
		//Time.timeScale = 1;
		//Destroy (gameObject);
		GetComponent<AudioSource>().Play ();
		Application.LoadLevel("main_menu");
	}
	/*void OnTouchUp()
	{

	}
	void OnTouchStay()
	{
		Destroy (gameObject);
	}
	void OnTouchExit()
	{

	}*/
}

