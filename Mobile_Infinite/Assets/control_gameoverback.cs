using UnityEngine;
using System.Collections;

public class control_gameoverback : MonoBehaviour {

	void OnTouchDown()
	{
		AudioListener.volume = 1;
		Application.LoadLevel("main_menu");
	}
}
