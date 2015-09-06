using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class continue_no : MonoBehaviour {
	public Text costtext;
	public Color c1;
	public GameObject dialog;
	void OnTouchDown()
	{
		dialog.transform.Translate (0,-8,0);
		costtext.color = c1;
	}
}
