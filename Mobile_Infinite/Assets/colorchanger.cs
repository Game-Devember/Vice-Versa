using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class colorchanger : MonoBehaviour {
	public Color[] c;
	//public Color c1;
	private GameObject[] G = null;
	private GameObject[] bricks = null;
	public Text[] GOtext = null;
	private Material mat;
	private int index;
	public GameObject GO;
	void Start () {
		index = PlayerPrefs.GetInt ("THEME");
		index++;
		if (index >= c.Length) {
			index=0;
		}

		G = GameObject.FindGameObjectsWithTag ("colorchangers");
		bricks = GameObject.FindGameObjectsWithTag ("colorchangers2");

		foreach (GameObject go in G) {
						go.GetComponent<SpriteRenderer> ().color = c[index];
				}
		foreach( GameObject go in bricks)
		{
			go.GetComponent<MeshRenderer> ().material.color = c[index];
		}

		PlayerPrefs.SetInt("THEME",index);
	}
	
	void Update () {
		bricks = GameObject.FindGameObjectsWithTag ("colorchangers2");
		if (GO.GetComponent<gameover> ().i) {
			foreach(Text t in GOtext)
			{
				t.color = Color.Lerp(t.color,c [index],Time.deltaTime);
			}
				}
		foreach( GameObject go in G)
		{
			go.GetComponent<SpriteRenderer> ().color= Color.Lerp(go.GetComponent<SpriteRenderer> ().color,c[index],Time.deltaTime/3);
		}
		foreach( GameObject go in bricks)
		{
			go.GetComponent<MeshRenderer> ().material.color= Color.Lerp(go.GetComponent<MeshRenderer> ().material.color,c[index],Time.deltaTime*2);
		}
				}
	}

