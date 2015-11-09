using UnityEngine;
using System.Collections;

public class control_gameoverback : MonoBehaviour {

	void OnTouchDown()
	{
		PlayerPrefs.SetInt ("PREVCOINS", 0);
		Application.LoadLevel("main_menu");
	}
}
