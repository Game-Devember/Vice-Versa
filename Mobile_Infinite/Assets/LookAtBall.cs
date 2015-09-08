using UnityEngine;
using System.Collections;

public class LookAtBall : MonoBehaviour {

	private GameObject ballref;
	public GameObject portalref;
	public GameObject twinportal;
	void Start()
	{
		ballref = GameObject.FindGameObjectWithTag("ballref");
	}
	void Update () {
		transform.LookAt (ballref.transform);
		transform.position = new Vector3(-portalref.transform.position.x,transform.position.y,transform.position.z);
		twinportal.transform.rotation = transform.rotation;
	}

}
