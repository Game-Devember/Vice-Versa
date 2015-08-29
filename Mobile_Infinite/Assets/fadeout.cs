using UnityEngine;
using System.Collections;

public class fadeout : MonoBehaviour {
	public GUIText g;
	public Color c2;
	public string s;
	// Use this for initialization
	void Start () {
		g.GetComponent<GUIText>().text = "HOLD TO\nGO " + s;
	}
	
	// Update is called once per frame
	void Update () {
		g.GetComponent<GUIText>().color = Color.Lerp (g.GetComponent<GUIText>().color, c2, Time.deltaTime * 0.8f);
		Destroy (gameObject, 5.0f);
	}
}
