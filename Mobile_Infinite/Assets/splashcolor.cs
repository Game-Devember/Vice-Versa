using UnityEngine;
using System.Collections;

public class splashcolor : MonoBehaviour {
	public Color c2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.Lerp (this.gameObject.GetComponent<SpriteRenderer> ().color,c2,Time.deltaTime*0.5f);
	}
}
