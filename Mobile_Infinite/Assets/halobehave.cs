using UnityEngine;
using System.Collections;

public class halobehave : MonoBehaviour {
	public Color c1;
	public Color c2;
	private Material mat;
	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
		mat.color = c1;
		Destroy (this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3(0.005F, 0.005f, 0.005f); 
		mat.color = Color.Lerp (mat.color,c2,Time.deltaTime*5);
	}
	/*void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "coin")
		{
		Destroy(col.gameObject);
		}
	}*/
}
