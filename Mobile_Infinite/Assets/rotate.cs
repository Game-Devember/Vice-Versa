using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	private GameObject ballref;
	public float c;
	public float rot;
	//public GUIText coincounter;
	private static int coincount = 0;
	public bool distenable = true;
	private float d;

	void Start()
	{
		PlayerPrefs.SetInt("COINCOUNT",PlayerPrefs.GetInt("PREVCOINS"));
		ballref = GameObject.FindWithTag("ballref");
		/*if (PlayerPrefs.GetInt ("CONTINUEINDEX") > 0) {
						coincount = PlayerPrefs.GetInt ("PREVCOINS");
				} 
		else if (PlayerPrefs.GetInt ("CONTINUEINDEX") == 0) {
						coincount = 0;
				}*/

	}
	void Update () {
		this.transform.Rotate(new Vector3(0,rot,0));
		if (distenable) {
						d = Vector3.Distance (this.transform.position, ballref.transform.position);
				}
		//Debug.Log (d.ToString ());
		PlayerPrefs.SetInt("COINCOUNT",coincount);

		if (d <= c) {
			coincount=coincount+1;
			//Debug.Log(coincount);

			GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo.transform.Translate(transform.position.x,transform.position.y,transform.position.z);
			//coincounter.text = coincount.ToString();
			Destroy(this.gameObject);
				}
	}
	void OnLevelWasLoaded(int level)
	{
		if (level == 1) {
			coincount = 0;
				}
	}
}