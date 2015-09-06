using UnityEngine;
using System.Collections;

public class control_gameoverback : MonoBehaviour {

	void OnTouchDown()
	{
		Application.LoadLevel("main_menu");
	}
}
