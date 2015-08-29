using UnityEngine;
using System.Collections;

public class brickbehave : MonoBehaviour {
	private GameObject cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (cam.transform.position.y - 8.0f > this.transform.position.y) {
			Destroy(this.gameObject);		
		}
	
	}
}
