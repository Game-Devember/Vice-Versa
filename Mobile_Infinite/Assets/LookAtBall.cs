using UnityEngine;
using System.Collections;

public class LookAtBall : MonoBehaviour {

	private GameObject ballref;
	void Start()
	{
		ballref = GameObject.FindGameObjectWithTag("ballref");
	}
	void Update () {
		transform.LookAt (ballref.transform);
	}

}
