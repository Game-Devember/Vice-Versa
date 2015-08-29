using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class back_control : MonoBehaviour {
	public GameObject cam;
	public GameObject coin;
	public GUIText g1;
	public GUIText g2;
	void OnTouchDown()
	{
		cam.transform.Translate(0,-11,0);
		coin.transform.Translate (0, 11, 0);
		g1.gameObject.GetComponent<GUIText> ().enabled = true;
		g2.gameObject.GetComponent<GUIText> ().enabled = true;
	}

}