using UnityEngine;
using System.Collections;

public class copyTransPup : MonoBehaviour {
	public GameObject r;
	//private int coincount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (-1 * r.transform.position.x, r.transform.position.y, r.transform.position.z);
	}
	/*void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "coin") {
			coincount++;
			Debug.Log("Yo"+coincount);
			Destroy(col.gameObject);
		}
	}*/
}
