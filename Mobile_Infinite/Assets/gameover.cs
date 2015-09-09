using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameover : MonoBehaviour {
	public GameObject ball;
	public GameObject g1=null;
	public GameObject g2=null;
	public GameObject control_g;

	public GameObject halo;

	public Text textdisp;
	public Text scoredisp;
	public Text bestdisp;
	public GameObject coindisp;
	public Text cointext;

	private GameObject shatter;
	public GameObject ballref;
	public GameObject cam;

	public Color c1;
	public Color c2;
	public Color best_c;
	//public Color defc;

	private Material mat;
	private Material mat2;
	public bool i=false;

	private int c=0;
	public collisions co;
	private float curtime = 1000000f;
	void Start()
	{
		Time.timeScale = 1;
		if (PlayerPrefs.GetInt ("PLAYCOUNT") == 30) {
						Social.ReportProgress ("CgkI1OiZi54dEAIQBg", 100.0f, (bool success) => {
								Debug.Log ("playcount30");
						});
				}
		if (PlayerPrefs.GetInt ("PLAYCOUNT") == 60) {
				Social.ReportProgress("CgkI1OiZi54dEAIQAQ", 100.0f,(bool success) =>{
					Debug.Log("playcount60");
				});
				}
		if (PlayerPrefs.GetInt ("PLAYCOUNT") == 100) {
			Social.ReportProgress("CgkI1OiZi54dEAIQCg", 100.0f,(bool success) =>{
				Debug.Log("playcount100");
			});
		}

		//best_s.guiText.color;
		mat = g2.GetComponent<Renderer>().material;
		mat.color = c1;
		mat2 = g1.GetComponent<Renderer>().material;
		mat2.color = c1;
	}
	void Update()
	{
			if (i == true) {
			mat.color = Color.Lerp(mat.color,c2,Time.deltaTime);
			mat2.color = Color.Lerp(mat2.color,c2,Time.deltaTime);

			checkHighScore();

			scoredisp.text = co.retscore().ToString();
			bestdisp.text = PlayerPrefs.GetInt ("HIGHSCORE").ToString();
			scoredisp.color = Color.Lerp(scoredisp.color,best_c,Time.deltaTime);
			bestdisp.color = Color.Lerp(scoredisp.color,best_c,Time.deltaTime);
			textdisp.color = Color.Lerp(textdisp.color,best_c,Time.deltaTime);
			cointext.color = Color.Lerp(cointext.color,best_c,Time.deltaTime);
			if(Time.time - curtime >= 0 && Time.time - curtime < 3.0f)
			{
				coindisp.GetComponent<Rigidbody2D> ().velocity = ((new Vector3(42f,-19.1f,-6.1f) - new Vector3(158,89.7f,25f)).normalized) * 10;
			}
			if(Time.time - curtime > 0.79f)
			{
				coindisp.GetComponent<Rigidbody2D> ().velocity = new Vector3(0,0,0);
			}

			/*if(cam.transform.position.y>ballref.transform.position.y+0.8f){
			cam.transform.position += new Vector3 (0, -0.1f, 0);
			}*/
			/*ball.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
			ball.gameObject.GetComponent<Rigidbody2D>().mass = 0;*/
			ball.transform.Translate(10,0,0);
			}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Hero") {
			//Time.timeScale = Mathf.Lerp(Time.timeScale,0.4f,1);
			curtime = Time.time;
			//Debug.Log("GameOver!");
			//Destroy(ball.gameObject);
			//GetComponent<collisions>().enabled= false;

			//Destroy(halo.gameObject);
			//shatter = Instantiate(Resources.Load("Prefabs/ball_shatter")) as GameObject;
			//shatter.transform.Translate(ballref.transform.position.x,ballref.transform.position.y-1f,-3f);
			//shatter.GetComponent<Animator>().Play("Take 001");
			//GetComponent<Animation>().wrapMode=WrapMode.Once;
			ballref.GetComponent<MeshRenderer>().enabled = false;
			GetComponent<AudioSource>().Play ();
				i=true;
			//Application.LoadLevel("end_menu");
			//co = ball.gameObject.GetComponent<collisions>();
			c = co.retscore();
			PlayerPrefs.SetInt("PREVSCORE",c);
			if(PlayerPrefs.GetInt("HIGHSCORE")==0)
			{
				PlayerPrefs.SetInt("PLAYCOUNT",0);
			}
			int a=PlayerPrefs.GetInt("PLAYCOUNT");
			a++;
			PlayerPrefs.SetInt("PLAYCOUNT",a);
			a=0;
			Social.ReportScore (PlayerPrefs.GetInt ("HIGHSCORE"), "CgkI1OiZi54dEAIQBw", (bool success) => {
				Debug.Log("Score submitted");
			});
			control_g.transform.Translate(0,11,0);
			int con = PlayerPrefs.GetInt("TOTALCOINS")+PlayerPrefs.GetInt("COINCOUNT");
			PlayerPrefs.SetInt("PREVCOINS",PlayerPrefs.GetInt("COINCOUNT"));
			cointext.text = con.ToString();
			PlayerPrefs.SetInt("TOTALCOINS",con);
			//Debug.Log (c);
		}
	}
	void checkHighScore()
	{
		if (PlayerPrefs.GetInt ("HIGHSCORE") < c) {
			PlayerPrefs.SetInt("HIGHSCORE",c);
		}
	}
}