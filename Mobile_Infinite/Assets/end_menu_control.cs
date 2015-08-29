using UnityEngine;
using System.Collections;

public class end_menu_control : MonoBehaviour {
	void OnTouchDown()
	{
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
