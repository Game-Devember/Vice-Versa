using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class leaderboard_control : MonoBehaviour {
	bool flogin=false;
	void Start()
	{
		PlayGamesPlatform.Activate ();
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
		Social.ReportScore (PlayerPrefs.GetInt ("HIGHSCORE"), "CgkI1OiZi54dEAIQBw", (bool success) => {
			Debug.Log("Score submitted");
		});
		Social.localUser.Authenticate((bool success) =>{
		if (success)
		{
			PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI1OiZi54dEAIQBw");
			Debug.Log("You've successfully logged in");
		}
		else
		{
			Debug.Log("Login failed for some reason");
			flogin=true;
		}
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
}