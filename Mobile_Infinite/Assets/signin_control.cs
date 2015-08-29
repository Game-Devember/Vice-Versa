using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class signin_control : MonoBehaviour {
	//public GUIText bst;
	private bool flogin=false;
	void Start()
	{
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate((bool success) =>
		                              {
			if(!success)
			{
				Debug.Log("Not signed In");
			}
		});
		checkach ();
		//bst.GetComponent<GUIText>().text = ("BEST: " + PlayerPrefs.GetInt ("HIGHSCORE").ToString());
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
		Social.localUser.Authenticate((bool success) =>
		                              {
			if (success)
			{
				Debug.Log("You've successfully logged in");
			}
			else
			{
				Debug.Log("Login failed for some reason");
				flogin=true;
			}
		});
		Social.ReportScore (PlayerPrefs.GetInt ("HIGHSCORE"), "CgkI1OiZi54dEAIQBw", (bool success) => {
			Debug.Log("Score submitted");
		});
	}
	void DoWindow0(int windowID){
		if (GUI.Button (new Rect (105,22, 60, 30), "OK")) {
			flogin=false		;
		}
		}
	void OnGUI()
	{
		if (flogin) {
			GUI.Window(0,new Rect((Screen.width/2)-135,(Screen.height/2)-30,270,60),DoWindow0,"Please Check your Internet Connection");
				}
	}
	void checkach()
	{
		int hscore = PlayerPrefs.GetInt("HIGHSCORE");
		if (hscore >=10) {
			Social.ReportProgress("CgkI1OiZi54dEAIQAA", 100.0f,(bool success) =>{
				Debug.Log("Scored 10");
			});
		}
		if (hscore >=25) {
			Social.ReportProgress ("CgkI1OiZi54dEAIQAg", 100.0f, (bool success) => {
				Debug.Log ("Scored 25");
			});
		}
		if (hscore >=40) {
			Social.ReportProgress ("CgkI1OiZi54dEAIQAw", 100.0f, (bool success) => {
				Debug.Log ("Scored 40");
			});
		}
		if (hscore >=50) {
			Social.ReportProgress("CgkI1OiZi54dEAIQBQ", 100.0f,(bool success) =>{
				Debug.Log("Scored 50");
			});
		}
		if (hscore >=75) {
			Social.ReportProgress("CgkI1OiZi54dEAIQBA", 100.0f,(bool success) =>{
				Debug.Log("Scored 75");
			});
		}
		if (hscore >=100) {
			Social.ReportProgress("CgkI1OiZi54dEAIQCQ", 100.0f,(bool success) =>{
				Debug.Log("Scored 100");
			});
		}
		if (hscore >=150) {
			Social.ReportProgress("CgkI1OiZi54dEAIQCw", 100.0f,(bool success) =>{
				Debug.Log("Scored 150");
			});
		}
		if (hscore >=200) {
			Social.ReportProgress("CgkI1OiZi54dEAIQDA", 100.0f,(bool success) =>{
				Debug.Log("Scored 200");
			});
		}
	}
}
