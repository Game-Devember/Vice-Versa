using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu_exit_control : MonoBehaviour {
	public Text bst;
	public Text cointext;
	void Start()
	{
		bst.text = ("BEST: " + PlayerPrefs.GetInt ("HIGHSCORE").ToString());
		cointext.text = PlayerPrefs.GetInt ("TOTALCOINS").ToString ();
		//cointext.GetComponent<GUIText> ().text = coins.ToString ();
	}
	void Update()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor) {
						if (Input.GetKey (KeyCode.Escape)) {
								Application.Quit();
								return;
						}
						//Time.timeScale = 0;
				}
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
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
		Application.Quit ();
		//UnityEditor.EditorApplication.isPlaying = false;
		//Application.LoadLevel("Level");
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
