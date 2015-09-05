using UnityEngine;
using System.Collections;

public class continue_control : MonoBehaviour {
	public int continuecost ;
	private int newcount;
	// Use this for initialization
	void Start()
	{
		newcount = 0;
		//PlayerPrefs.SetInt ("CONTINUEINDEX", 0);
		//PlayerPrefs.SetInt ("TOTALCOINS",500);
	}
	void OnTouchDown()
	{
		int c = PlayerPrefs.GetInt("CONTINUEINDEX");
		PlayerPrefs.SetInt ("CONTINUEINDEX", c + 1);
		newcount = (PlayerPrefs.GetInt ("TOTALCOINS") - ((c + 1) * continuecost));
		if (newcount >= 0) {
			PlayerPrefs.SetInt ("TOTALCOINS",newcount);
			Application.LoadLevel ("Level");
			Destroy(gameObject);
				}
	}
}
