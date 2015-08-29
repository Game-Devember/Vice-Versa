using UnityEngine;
using System.Collections;

public class exit_control : MonoBehaviour {

	// Use this for initialization
	void OnTouchDown()
	{
		Debug.Log("exit!");
		Application.LoadLevel ("Level");
		Destroy (gameObject);
	}
}
