using UnityEngine;
using System.Collections;

public class magnet : MonoBehaviour {
	GameObject ballref;
	GameObject ball;
	public float magspeed;
	bool magtaken;
	// Use this for initialization
	void Start () {
		ballref = GameObject.FindGameObjectWithTag("ballref");
		ball = GameObject.FindGameObjectWithTag("Hero");

	}
	
	// Update is called once per frame
	void Update () {
		magtaken = ball.gameObject.GetComponent<collisions>().magged;
		//this.transform.Translate ();
		if ((Vector3.Distance (ballref.transform.position, this.transform.position) < 4.0f) && magtaken) {
			this.GetComponent<Rigidbody2D> ().velocity = ((ballref.transform.position - this.transform.position).normalized) * magspeed;
				}
	}
}
