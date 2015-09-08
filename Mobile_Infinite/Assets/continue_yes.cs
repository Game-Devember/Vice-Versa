using UnityEngine;
using System.Collections;

public class continue_yes : MonoBehaviour {
	public int continuecost ;
	private int newcount;
	void Start () {
	}
	
	void OnTouchDown()
	{
		int c = PlayerPrefs.GetInt("CONTINUEINDEX");
		PlayerPrefs.SetInt ("CONTINUEINDEX", c + 1);
		newcount = (PlayerPrefs.GetInt ("TOTALCOINS") - ((c + 1) * continuecost));
		if (newcount >= 0) {
			PlayerPrefs.SetInt ("TOTALCOINS",newcount);
			PlayerPrefs.SetInt ("THEME",PlayerPrefs.GetInt ("THEME")-1);
			Application.LoadLevel ("Level");
			Destroy(gameObject);
		}
	}
}
