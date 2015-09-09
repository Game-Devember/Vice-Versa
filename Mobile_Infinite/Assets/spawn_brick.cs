using UnityEngine;
using System.Collections;

public class spawn_brick : MonoBehaviour {
	public GameObject g = null;
	public GameObject gref = null;
	public GameObject ball = null;
	//public float speed ;
	private GameObject powerup;
	private GameObject pup;
	private int i=0;
	private float prevx=0;
	private float prevy = 0;
	private float posx=1;
	private int prevplace;
	private int pupcount;
	public GameObject brick;
	private Renderer rend;
	public GameObject BG;

	// Use this for initialization
	void Start () {
		int colindex = PlayerPrefs.GetInt ("THEME") + 1;
		if (colindex == BG.GetComponent<colorchanger>().c.Length) {
			colindex = 0;
				}
		Color tcol = BG.GetComponent<colorchanger>().c[colindex];

		posx = Random.Range (0.7f, 3f);
		brick.transform.position = new Vector3(posx, 5.5f, -5);
		Instantiate (brick);
		gref.transform.position = new Vector3(-posx, 5.5f, -5);
		g = Instantiate (gref) as GameObject;
		rend = g.GetComponent<Renderer>();
		rend.material.color = new Color (tcol.r, tcol.g, tcol.b, 0.6f);

		posx = 6.43f - Random.Range (-0.5f,0.5f);
		brick.transform.position = new Vector3(posx, 8f, -5);
		Instantiate (brick);
		gref.transform.position = new Vector3(-posx, 8f, -5);
		g = Instantiate (gref) as GameObject;
		rend = g.GetComponent<Renderer>();
		rend.material.color = new Color (tcol.r, tcol.g, tcol.b, 0.2f);


		if (PlayerPrefs.GetInt ("CONTINUEINDEX") > 0) {
			ball.transform.position = new Vector3(posx,9.25f,-5);
		}
		i = 0;
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

						
			if (ball.transform.position.y > prevy-8.0f) 
			{
				//posx = Random.Range(0.7f,7f);

				int place = Random.Range(1,6);

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
					brick.transform.position = new Vector3(posx,prevy+2.5f,-5);
					brick.transform.rotation = Quaternion.identity;
					Instantiate (brick,brick.transform.position,brick.transform.rotation);

					
					/*
					fadingBrick.transform.position = new Vector3(-posx,prevy-2.5f,-5);
					fadingBrick.transform.rotation = Quaternion.identity;
					Instantiate (fadingBrick,fadingBrick.transform.position,fadingBrick.transform.rotation);
					*/
				pupcount = Random.Range(0,4);

				if((i-1)%19 == 0)
				{		
					//g = Instantiate (Resources.Load ("Prefabs/Tele_main")) as GameObject;

					if(pupcount % 4 == 0 )
					{
						powerup = Instantiate (Resources.Load ("Prefabs/magnet")) as GameObject;
					}
					else if(pupcount % 4 == 1 )
					{
						powerup = Instantiate (Resources.Load ("Prefabs/Tele_main")) as GameObject;
					}
					else if(pupcount % 4 == 2 )
					{
						powerup = Instantiate (Resources.Load ("Prefabs/Rocket_inv")) as GameObject;
					}
					else if(pupcount % 4 == 3 )
					{
						powerup = Instantiate (Resources.Load ("Prefabs/shield")) as GameObject;
					}
					powerup.transform.Translate (prevx-4.4f,prevy -1.25f,-5);
				}

				if(((i-1)%2==0) )
				{
								pup = Instantiate (Resources.Load ("Prefabs/Coin")) as GameObject;
								pup.transform.Translate (prevx,(prevy+1.25f),5);
								pup = Instantiate (Resources.Load ("Prefabs/Coin")) as GameObject;
								pup.transform.Translate (-prevx,(prevy+1.25f), -5);

								/*g = Instantiate (Resources.Load ("Prefabs/score")) as GameObject;
						g.transform.Translate (posx, /*transform.position.y + 7.7f prevy + 2.6f, -2);*/
				}
								prevx = posx;
								prevy = prevy + 2.5f;
				i++;
						}
				}
	}
}
