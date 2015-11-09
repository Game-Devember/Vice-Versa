using UnityEngine;
using System.Collections;

public class retry_control : MonoBehaviour {

	// Use this for initialization
	void OnTouchDown()
	{
		PlayerPrefs.SetInt ("CONTINUEINDEX", 0);
		PlayerPrefs.SetInt ("PREVCOINS", 0);
		AudioListener.volume = PlayerPrefs.GetInt("GAMEVOLUME");
		Application.LoadLevel ("Level");
		Destroy (gameObject);
	}
}
