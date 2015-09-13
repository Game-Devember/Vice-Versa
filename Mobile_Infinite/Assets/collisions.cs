using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GooglePlayGames;

public class collisions : MonoBehaviour {
	public Color trailcolor;
	public float height;
	public GameObject ballref;
	private int score;
	public Text st;
	public Text coincounter;
	public GameObject cam = null;

	public GameObject shield = null;
	public AudioClip[] pupsaudio = null;

	public Color c1;
	public Color c2;
	private int i=0;
	//private int coincount = 0;
	private Collider2D c;
	private float beforepup;
	private bool hypered = false;
	private float curtime = 1000000f;
	private float curtime2 = 1000000f;
	private float curtimehyp = 1000000f;
	private float curtimeshi = 1000000f;
	public GameObject controlleft;
	public GameObject controlright;

	private int prevscore;
	public GameObject maghalo;
	public bool magged = false;
	private Material mat;
	private Material mat2;
	private Material matshi;
	private bool poweredup;
	//private int prevcoins;
	//private Transform t;
	void Start()
	{
		mat = gameObject.GetComponent<MeshRenderer> ().material;
		mat2 = maghalo.gameObject.GetComponent<MeshRenderer> ().material;
		matshi = shield.gameObject.GetComponent<MeshRenderer> ().material;
		i = 0;
		st.color = c1;
		if (PlayerPrefs.GetInt ("CONTINUEINDEX") > 0) {
			prevscore = PlayerPrefs.GetInt("PREVSCORE")-9;
			//prevcoins = PlayerPrefs.GetInt("PREVCOINS");
			PlayerPrefs.SetInt("COINCOUNT",PlayerPrefs.GetInt("PREVCOINS"));
				}
		else if(PlayerPrefs.GetInt ("CONTINUEINDEX") == 0) {
			prevscore=0;
			//prevcoins = 0;
				}
	}
	void Update()
	{	
				coincounter.text = PlayerPrefs.GetInt ("COINCOUNT").ToString ();
				score = Mathf.RoundToInt (cam.transform.position.y);
				i++;
				if (i < 10) {
						st.color = c1;
				} else {
						st.color = Color.Lerp (st.color, c2, Time.deltaTime * 3f);
						if (i >= 120) {
								st.color = c2;
						}
				}
		st.text = (score+prevscore).ToString ();
				if (hypered) {
						float c1 = ballref.gameObject.GetComponent <TrailRenderer> ().startWidth;
						ballref.gameObject.GetComponent <TrailRenderer> ().startWidth = Mathf.Lerp(c1,0,Time.deltaTime*0.5f);
						float c2 = ballref.gameObject.GetComponent <TrailRenderer> ().endWidth;
						ballref.gameObject.GetComponent <TrailRenderer> ().endWidth = Mathf.Lerp(c2,0,Time.deltaTime*0.5f);
						float c3 = ballref.gameObject.GetComponent<TrailRenderer>().time;
						ballref.gameObject.GetComponent<TrailRenderer>().time = Mathf.Lerp(c3,0,Time.deltaTime);

						if (/*this.transform.position.x > 0 && */this.transform.position.x < 0.55f) {
								GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 1400f);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x,GetComponent<Rigidbody2D>().velocity.y);
						}
						if (this.transform.position.x > 7.7f /*&& this.transform.position.x < 8.2f*/) {
								GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -1400f);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x,GetComponent<Rigidbody2D>().velocity.y);
						}
			GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,35);
			//Debug.Log((Time.time - curtimehyp).ToString());

			if (Time.time - curtimehyp >= 1f) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,GetComponent<Rigidbody2D> ().velocity.y/2);
				hypered = false;
				c.isTrigger = false;
				curtimehyp = 1000000f;
			}
				}
		if (this.GetComponent<Rigidbody2D> ().velocity.y <= 0 && !hypered) {
			ballref.gameObject.GetComponent <TrailRenderer> ().enabled = false;
			//this.GetComponent<MeshRenderer>().enabled = true;
		}
			//GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,10);
			

		if(Time.time-curtime >= 6 )
		{
			//mat.color = Color.Lerp(mat.color,c1,Time.deltaTime*4);
			mat.color = Color.Lerp(mat.color,c1,Time.deltaTime*3);
			if(poweredup)
			{
				StartCoroutine("Blink");
				poweredup = false;
			}
		}

		if(Time.time-curtime2 >= 6 )
		{
			mat2.color = Color.Lerp(mat2.color,c1,Time.deltaTime*3);
			if(poweredup)
			{
				StartCoroutine("Blink");
				poweredup = false;
			}
		}

		if (Time.time - curtimeshi >= 6) {
			matshi.color = Color.Lerp(matshi.color,c1,Time.deltaTime*3);
			if(poweredup)
			{
				StartCoroutine("Blink");
				poweredup = false;
			}
				}
		if(Time.time-curtime >= 10.0f)
		{
			mat.color = c2;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.gameObject.GetComponent<TrailRenderer> ().enabled = false;
			ballref.gameObject.GetComponent<MeshRenderer>().enabled = true;
			ballref.transform.FindChild("halocontrol").gameObject.GetComponent<TrailRenderer>().enabled = true;
			curtime = 1000000f;
			GameObject halo1 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo1.transform.Translate(transform.position.x,transform.position.y,transform.position.z);
			GameObject halo2 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo2.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
			controlleft.GetComponent<Control> ().speed = controlleft.GetComponent<Control> ().speed * -1;
			controlright.GetComponent<Control> ().speed = controlright.GetComponent<Control> ().speed * -1;
			}
		if (Time.time - curtime2 >= 10.0f) {
			mat2.color = c2;
			magged = false;
			curtime2 = 1000000f;
			GameObject halo2 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			maghalo.gameObject.GetComponent<MeshRenderer> ().enabled = false;
			halo2.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
				}
		if (Time.time - curtimeshi >= 10.0f) {
			matshi.color = c2;
			shield.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			shield.gameObject.GetComponent<MeshRenderer>().enabled = false;
			curtimeshi = 1000000f;
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "wall") {
						GetComponent<Rigidbody2D>().AddForce (Vector2.right * -1);
				} 
		if (col.gameObject.tag == "brick" || col.gameObject.tag == "updown") {
			//GetComponent<AudioSource>().Play ();
		}
		if(col.gameObject.tag == "brick")
		{
			//transform.Translate(0,height,0);
			//rigidbody2D.position += (Vector2.up * height );
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * height * 120);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "puphyper") {
			GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
			Activatepuphyper();
			GetComponent<AudioSource>().clip = pupsaudio[0];
			GetComponent<AudioSource>().Play ();
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == "puptele") {
			Activatepuptele();
			GetComponent<AudioSource>().clip = pupsaudio[1];
			GetComponent<AudioSource>().Play ();
			Destroy(col.gameObject);
				}
		if (col.gameObject.tag == "pupmag") {
			Activatepupmag();
			GetComponent<AudioSource>().clip = pupsaudio[2];
			GetComponent<AudioSource>().Play ();
			Destroy(col.gameObject);
				}
		if (col.gameObject.tag == "pupshield") {
			poweredup = true;
			shield.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			shield.gameObject.GetComponent<MeshRenderer>().enabled = true;
			GameObject halo2 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo2.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
			curtimeshi = Time.time;
			Destroy(col.gameObject);
				}

		if (score >=100) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQAA", 100.0f,(bool success) =>{
				//Debug.Log("Scored 10");
			});
		}
		if (score >=250) {
			Social.ReportProgress ("CgkI7bOmyN8IEAIQAQ", 100.0f, (bool success) => {
				//Debug.Log ("Scored 25");
			});
		}
		if (score >=500) {
			Social.ReportProgress ("CgkI7bOmyN8IEAIQAg", 100.0f, (bool success) => {
				//Debug.Log ("Scored 40");
			});
		}
		if (score >=750) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQAw", 100.0f,(bool success) =>{
				//Debug.Log("Scored 50");
			});
		}
		if (score >=1000) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQBA", 100.0f,(bool success) =>{
				//Debug.Log("Scored 100");
			});
		}
		if (score >=1500) {
			Social.ReportProgress("CgkI7bOmyN8IEAIQBQ", 100.0f,(bool success) =>{
				//Debug.Log("Scored 150");
			});
		}
	}
	public int retscore()
	{
		return (score+prevscore);
	}

	public void Activatepuphyper()
	{
		hypered = true;
		c = this.gameObject.GetComponent<Collider2D>();
		c.isTrigger = true;
		ballref.gameObject.GetComponent <TrailRenderer> ().startWidth = 0.7f;
		ballref.gameObject.GetComponent <TrailRenderer> ().endWidth = 0.7f;
		ballref.gameObject.GetComponent <TrailRenderer> ().time = 0.5f;
		ballref.gameObject.GetComponent <TrailRenderer>().enabled = true;
		curtimehyp = Time.time;
	}
	public void Activatepuptele()
	{
		poweredup = true;
		this.gameObject.GetComponent<MeshRenderer>().enabled = true;
		this.gameObject.GetComponent<TrailRenderer> ().enabled = true;
		ballref.gameObject.GetComponent<MeshRenderer>().enabled = false;
		ballref.transform.FindChild("halocontrol").gameObject.GetComponent<TrailRenderer>().enabled = false;
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,GetComponent<Rigidbody2D> ().velocity.y);
		GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
		halo.transform.Translate(transform.position.x,transform.position.y,transform.position.z);
		GameObject halo2 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
		halo2.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
		curtime = Time.time;
		controlleft.GetComponent<Control> ().speed = controlleft.GetComponent<Control> ().speed * -1;
		controlright.GetComponent<Control> ().speed = controlright.GetComponent<Control> ().speed * -1; 

	}
	public void Activatepupmag()
	{
		poweredup = true;
		GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
		halo.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
		magged = true;
		maghalo.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		curtime2 = Time.time;
	}
	public IEnumerator Blink()
	{
		yield return new WaitForSeconds (0.25f);
		StartCoroutine("Fade");
		yield return new WaitForSeconds (0.25f);
		poweredup = true;
	}
	public void Fade()
	{
		mat.color = c2;
		mat2.color = c2;
		matshi.color = c2;
		/*mat.color = Color.Lerp (mat.color,c2,Time.deltaTime*4);
		mat2.color = Color.Lerp (mat2.color,c2,Time.deltaTime*4);*/
	}
	public void playcoin()
	{
		shield.GetComponent<AudioSource> ().Play ();
	}
}