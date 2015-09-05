using UnityEngine;
using System.Collections;

public class spawn_brick : MonoBehaviour {
	public GameObject g = null;
	public GameObject gref = null;
	public GameObject gref2 = null;
	public GameObject ball = null;
	public GameObject cam = null;
	//public float speed ;
	private GameObject pup;
	private int i=0;
	private int p=0;
	private float prevx=0;
	private float prevy = 0;
	private float posx=1;
	private float offset = 0.5f;
	private int prevplace;
	private int pupcount;
	// Use this for initialization
	void Start () {
		posx = Random.Range (0.7f, 3f);
		g = Instantiate (Resources.Load ("Prefabs/brick")) as GameObject;
		g.transform.Translate (posx, 5.5f, -5);
		gref.transform.Translate (-posx, 5.5f, -5);
		//posx = Random.Range (5f, 7.3f);
		posx = 6.43f - Random.Range (-0.5f,0.5f);
		g = Instantiate (Resources.Load ("Prefabs/brick")) as GameObject;
		g.transform.Translate (posx, 8f, -5);
		gref2.transform.Translate (-posx, 8f, -5);
		
		if (PlayerPrefs.GetInt ("CONTINUEINDEX") > 0) {
			ball.transform.position = new Vector3(posx,9.25f,-5);
		}
		prevx = posx;
		prevplace = 5;
		prevy = 8f;
	}
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.LoadLevel ("main_menu");
				// OR Application.Quit();
				
				return;
			}
		}
		if (Application.platform == RuntimePlatform.Android) {
						if (Input.GetKey (KeyCode.Escape)) {
								Application.LoadLevel ("main_menu");
								return;
						}
				}
		if (Time.timeScale == 1) 
		{

						
						if (ball.transform.position.y > prevy-4.0f) 
			{
				//posx = Random.Range(0.7f,7f);

				int place = Random.Range(1,6);
				g = Instantiate (Resources.Load ("Prefabs/brick")) as GameObject;
				if(place==1)
				{
					if(prevplace ==1)
					{
						posx = 5;
						prevplace=4;
					}
					else
					{
						posx = 0.7f;
						prevplace=1;
					}
					//goto pla;
				}
				else if(place==2)
				{
					if(prevplace ==2)
					{
						posx = 7.85f;
						prevplace=6;
					}
					else
					{
						posx = 2.12f;
						prevplace=2;
					}
					//goto pla;
				}
				else if(place==3)
				{
					if(prevplace ==3)
					{
						posx = 0.7f;
						prevplace=1;
					}
					else
					{
						posx = 3.56f;
						prevplace=3;
					}
					//goto pla;
				}
				else if(place==4)
				{
					if(prevplace ==4)
					{
						posx = 2.12f;
						prevplace=2;
					}
					else
					{
						posx = 5;
						prevplace=4;
					}
					//goto pla;
				}
				else if(place==5)
				{
					if(prevplace ==5)
					{
						posx = 3.56f;
						prevplace=3;
					}
					else
					{
						posx = 6.43f;
						prevplace=5;
					}
					//goto pla;
				}
				else if(place==6)
				{
					if(prevplace ==5)
					{
						posx = 6.43f;
						prevplace=5;
					}
					else
					{
						posx = 7.85f;
						prevplace=6;

					}
				}
			pla:
								g.transform.Translate (posx, /*transform.position.y*/ prevy + 2.5f, -5);
				
				/*if(i%15 == 0)
				{
					g = Instantiate (Resources.Load ("Prefabs/Rocket_inv")) as GameObject;
					g.transform.Translate (0,prevy + 1.25f,1);
				}*/
				/*if(cam.transform.position.y>prevy)
				{
					Destroy (g.gameObject);
				}*/
				pupcount = Random.Range(0,7);
				if((i-1)%19 == 0)
				{
					if(pupcount % 4 == 0 )
					{
						g = Instantiate (Resources.Load ("Prefabs/magnet")) as GameObject;
					}
					else if(pupcount % 4 == 1 )
					{
						g = Instantiate (Resources.Load ("Prefabs/Tele_main")) as GameObject;
					}
					else if(pupcount % 4 == 2 )
					{
						g = Instantiate (Resources.Load ("Prefabs/Rocket_inv")) as GameObject;
					}
					else if(pupcount % 4 == 3 )
					{
						g = Instantiate (Resources.Load ("Prefabs/shield")) as GameObject;
					}
					g.transform.Translate (0,prevy + 1.25f,-5);
				}
								
				if((i%2==0) )
				{
					float p;
					/*if(i%4 == 0)
					{
						p = prevx;
					}
					else{
						p = posx;
					}*/
					p = prevx;
								pup = Instantiate (Resources.Load ("Prefabs/Coin")) as GameObject;
								pup.transform.Translate (p,(prevy+1.25f),5);
								pup = Instantiate (Resources.Load ("Prefabs/Coin")) as GameObject;
								pup.transform.Translate (-p,(prevy+1.25f), -5);

								/*g = Instantiate (Resources.Load ("Prefabs/score")) as GameObject;
						g.transform.Translate (posx, /*transform.position.y + 7.7f prevy + 2.6f, -2);*/
				}
				/*if(cam.transform.position.y>prevy)
				{
					Destroy (g.gameObject);
				}*/ 
								prevx = posx;
								prevy = prevy + 2.5f;
				i++;
						}
				}
	}
}
