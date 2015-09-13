using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class ach_control : MonoBehaviour {
	bool flogin=false;
	void Start()
	{
		PlayGamesPlatform.Activate ();
		if (Time.time <= 4f) {
						checkach ();
				}
	}
	void Update()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor) {
						if (Input.GetKey (KeyCode.Escape)) {
				PlayerPrefs.SetInt ("CONTINUEINDEX", 0);
								Application.Quit();
								return;
						}
				}
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				PlayerPrefs.SetInt ("CONTINUEINDEX", 0);
				Application.Quit ();
				return;
			}
		}
		}
	void OnTouchDown()
	{
		GetComponent<AudioSource>().Play ();
		Social.ReportScore (PlayerPrefs.GetInt ("HIGHSCORE"), "CgkI7bOmyN8IEAIQBg", (bool success) => {
			Debug.Log("Score submitted");
		});
		Social.localUser.Authenticate((bool success) =>{
			if (success)
			{
				Social.ShowAchievementsUI ();
				Debug.Log("You've successfully logged in");
			}
			else
			{
				Debug.Log("Login failed for some reason");
				flogin=true;
			}
		});
	}
	/*void DoWindow0(int windowID){
		if (GUI.Button (new Rect (105,22, 60, 30), "OK")) {
			flogin=false		;
		}
	}
	void OnGUI()
	{
		if (flogin) {
			GUI.Window(0,new Rect((Screen.width/2)-135,(Screen.height/2)-30,270,60),DoWindow0,"Please Check your Internet Connection");
		}
	}*/
	void checkach()
	{
		int hscore = PlayerPrefs.GetInt("HIGHSCORE");
		if (hscore >=100) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQAA", 100.0f,(bool success) =>{
				//Debug.Log("Scored 10");
			});
		}
		if (hscore >=250) {
			Social.ReportProgress ("CgkI7bOmyN8IEAIQAQ", 100.0f, (bool success) => {
				//Debug.Log ("Scored 25");
			});
		}
		if (hscore >=500) {
			Social.ReportProgress ("CgkI7bOmyN8IEAIQAg", 100.0f, (bool success) => {
				//Debug.Log ("Scored 40");
			});
		}
		if (hscore >=750) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQAw", 100.0f,(bool success) =>{
				//Debug.Log("Scored 50");
			});
		}
		if (hscore >=1000) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQBA", 100.0f,(bool success) =>{
				//Debug.Log("Scored 100");
			});
		}
		if (hscore >=1500) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQBQ", 100.0f,(bool success) =>{
				//Debug.Log("Scored 150");
			});
		}
	}
}
