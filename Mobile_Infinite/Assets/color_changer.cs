using UnityEngine;
using System.Collections;

public class color_changer : MonoBehaviour {
	public Color c1;
	public Color c2;
	public Color c3;
	public Color c4;
	public Color c5;
	public Color c6;

	public GameObject g;
	public GameObject wall2;
	public GameObject wallbg;
	public int value = 0;

	private Material mat;
	private Material mat2;
	private Material mat3;
	private Material mat4;
	private int a;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("THEME", 0);
		a = PlayerPrefs.GetInt("THEME");
		mat = GetComponent<Renderer>().material;
		mat2 = g.GetComponent<Renderer>().material;
		mat3 = wall2.GetComponent<Renderer>().material;
		mat4 = wallbg.GetComponent<Renderer>().material;

		if (a == 0) {
						mat.color = c1;
			mat2.color = c1;
			mat3.color = c1;
			mat4.color = c1;
				}
		if (a == 1) {
			mat.color = c2;
			mat2.color = c2;
			mat3.color = c2;
			mat4.color = c2;
		}
		if (a == 2) {
			mat.color = c3;
			mat2.color = c3;
			mat3.color = c3;
			mat4.color = c3;
		}
		if (a == 3) {
			mat.color = c4;
			mat2.color = c4;
			mat3.color = c4;
			mat4.color = c4;
		}
		if (a == 4) {
			mat.color = c5;
			mat2.color = c5;
			mat3.color = c5;
			mat4.color = c5;
				}
		if (a == 5) {
			mat.color = c6;
			mat2.color = c6;
			mat3.color = c6;
			mat4.color = c6;
		}
		if (a == 6) {
			a=0;
				}
		a = a + value;
		PlayerPrefs.SetInt ("THEME", a);
	}
}
