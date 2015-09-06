using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class continue_control : MonoBehaviour {
	public Text costtext;
	
	public Color c1;
	public Color c2;

	public GameObject dialog;

	void Start()
	{
		costtext.color = c1;

	}
	void OnTouchDown()
	{
		dialog.transform.Translate (0,8,0);
		int c = PlayerPrefs.GetInt("CONTINUEINDEX");
		costtext.text = ((c + 1) * 50).ToString();
		costtext.color = c2;

	}
}
