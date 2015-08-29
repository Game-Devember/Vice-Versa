using UnityEngine;
using System.Collections;

public class cam_move : MonoBehaviour {
	//public float speed;
	public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 1) {
			if(ball.transform.position.y > this.transform.position.y)
			{
						//transform.Translate (0, speed + (Time.deltaTime * Time.deltaTime), 0);
				transform.position = new Vector3(transform.position.x,ball.transform.position.y,transform.position.z);
			}
				}
	}
}
