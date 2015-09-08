using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class continue_yes : MonoBehaviour {
	public int continuecost ;
	public Text cantcont;
	private int newcount;
	private bool cant = false;
	public Color c1;
	public Color c2;

	void Start () {

		cant = false;
		cantcont.color = c1;
		//PlayerPrefs.SetInt ("TOTALCOINS", 140);
	}
	
	void OnTouchDown()
	{
		int c = PlayerPrefs.GetInt("CONTINUEINDEX");
		newcount = (PlayerPrefs.GetInt ("TOTALCOINS") - ((c + 1) * continuecost));
		if (newcount >= 0) {
			PlayerPrefs.SetInt ("CONTINUEINDEX", c + 1);
						PlayerPrefs.SetInt ("TOTALCOINS", newcount);
						PlayerPrefs.SetInt ("THEME", PlayerPrefs.GetInt ("THEME") - 1);
						Application.LoadLevel ("Level");
						Destroy (gameObject);
				}
		else {
			cantcont.color = c2;
			cant = true;
				}
	}
	void Update()
	{
		if(cant)
		{
			cantcont.color = Color.Lerp (cantcont.color,c1,Time.deltaTime);
		}
	}
}
