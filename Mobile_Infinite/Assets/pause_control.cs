using UnityEngine;
using System.Collections;

public class pause_control : MonoBehaviour {
	private int t = 0;
	void Update()
	{
		if (t == 1) {
			Time.timeScale = 0;
		}
		if (t == 0) {
			Time.timeScale = 1;
		}
		//Time.timeScale = 0;
	}
	void OnTouchDown()
	{
		t++;
		if (t >= 2) {
			t=0;
				}
		//Debug.Log("pause!");
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
