using UnityEngine;
using System.Collections;

public class menu_control : MonoBehaviour {
	public GUIText bst;
	void Start()
	{
		PlayerPrefs.SetInt ("CONTINUEINDEX", 0);
		bst.GetComponent<GUIText>().text = ("BEST: " + PlayerPrefs.GetInt ("HIGHSCORE").ToString());
	}
	void Update()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor) {
						if (Input.GetKey (KeyCode.Escape)) {
								Application.Quit();
								//UnityEditor.EditorApplication.isPlaying = false;
								return;
						}
						//Time.timeScale = 0;
				}
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
				//UnityEditor.EditorApplication.isPlaying = false;
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
		Application.LoadLevel("Level");
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
