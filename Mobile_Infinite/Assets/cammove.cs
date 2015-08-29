using UnityEngine;
using System.Collections;

public class cammove : MonoBehaviour {
	Vector3 currentAngle;
	Vector3 targetAngle = new Vector3(0f, 0f, 0f);
	// Use this for initialization
	void Start () {
		//this.transform.Translate (-17.72f, 0, -10);
		currentAngle = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 2.5f) {
						currentAngle = new Vector3 (0f, Mathf.LerpAngle (currentAngle.y, targetAngle.y, Time.deltaTime * 1.25f), 0f);
						transform.eulerAngles = currentAngle;
				}
		//yield return WaitForSeconds (2.0f);
		//this.transform.position += new Vector3(Mathf.Lerp(0f,17.72f,Time.deltaTime * 10f),0,-10);
	}
}
