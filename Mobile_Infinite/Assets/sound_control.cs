using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class sound_control : MonoBehaviour {
	private int c = 0;
	public GameObject bar;
	void Start()
	{
		if (PlayerPrefs.GetInt ("PLAYCOUNT") == 0) {
			PlayerPrefs.SetInt("GAMEVOLUME",1);
				}
		AudioListener.volume = c = PlayerPrefs.GetInt("GAMEVOLUME");
		if (c == 1) {
						bar.GetComponent<SpriteRenderer> ().enabled = false;
			Debug.Log("c==1");
			PlayerPrefs.SetInt ("PLAYCOUNT",1);
				}
		else if (c%2 == 0) {
			bar.GetComponent<SpriteRenderer> ().enabled = true;
			PlayerPrefs.SetInt("GAMEVOLUME",0);
			AudioListener.volume = 0;
			Debug.Log("c%2==0");
			PlayerPrefs.SetInt ("PLAYCOUNT",1);
				}
	}
	void OnTouchDown()
	{
		c++;
	}
	void Update()
	{
		if (c % 2 == 0) {
			AudioListener.volume = 0;
			PlayerPrefs.SetInt("GAMEVOLUME",0);
			bar.GetComponent<SpriteRenderer> ().enabled = true;
		}
		else {
			AudioListener.volume = 1;
			PlayerPrefs.SetInt("GAMEVOLUME",1);
			bar.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}