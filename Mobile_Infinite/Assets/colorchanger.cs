using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class colorchanger : MonoBehaviour {
	public Color[] c;
	public Color c1;
	/*public Color c2;
	public Color c3;
	public Color c4;
	public Color c5;*/
	private GameObject[] G;
	private GameObject[] bricks;
	private GameObject scoretext ;
	private Material mat;
	private int index=0;
	private float curtime;
	// Use this for initialization
	void Start () {
		scoretext = GameObject.FindGameObjectWithTag ("scoretext");
		G = GameObject.FindGameObjectsWithTag ("colorchangers");
		bricks = GameObject.FindGameObjectsWithTag ("colorchangers2");

		foreach (GameObject go in G) {
						go.GetComponent<SpriteRenderer> ().color = c1;
				}
		foreach( GameObject go in bricks)
		{
			go.GetComponent<MeshRenderer> ().material.color = c1;
		}
		curtime = Time.time;
			}
	
	// Update is called once per frame
	void Update () {
		bricks = GameObject.FindGameObjectsWithTag ("colorchangers2");
		if (index >= c.Length) {
			index=0;
				}

		foreach( GameObject go in G)
		{
			go.GetComponent<SpriteRenderer> ().color= Color.Lerp(go.GetComponent<SpriteRenderer> ().color,c[index],Time.deltaTime/3);
		}
		foreach( GameObject go in bricks)
		{
			go.GetComponent<MeshRenderer> ().material.color= Color.Lerp(go.GetComponent<MeshRenderer> ().material.color,c[index],Time.deltaTime);
		}
		if (Time.time - curtime >= 15 ) {
			index++;
			curtime = Time.time;
				}
	}
}
