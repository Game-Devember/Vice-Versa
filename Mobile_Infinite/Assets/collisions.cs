using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class collisions : MonoBehaviour {
	public Color trailcolor;
	public float height;
	public GameObject ballref;
	private int score;
	public Text st;
	public Text coincounter;
	public GameObject cam = null;

	public GameObject shield = null;

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
	private int co = 0;
	private int co2 = 0;
	public GameObject controlleft;
	public GameObject controlright;

	private int prevscore;
	public GameObject maghalo;
	public bool magged = false;

	//private Transform t;
	void Start()
	{
		PlayerPrefs.SetInt("COINCOUNT",0);
		i = 0;
		st.color = c1;
		if (PlayerPrefs.GetInt ("CONTINUEINDEX") > 0) {
			prevscore = PlayerPrefs.GetInt("PREVSCORE")-9;
				}
		else if(PlayerPrefs.GetInt ("CONTINUEINDEX") == 0) {
			prevscore=0;
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
			GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x,20);
			Debug.Log((Time.time - curtimehyp).ToString());

			if (Time.time - curtimehyp >= 2.0f) {
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
			if (Time.time - curtimeshi >= 10.0f) {
			shield.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			shield.gameObject.GetComponent<MeshRenderer>().enabled = false;
			curtimeshi = 1000000f;
				}
		co++;
			if(Time.time-curtime >= 7)
			{
					if(co%2==0){
				this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else{
				this.gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			}
		co2++;
		if(Time.time-curtime2 >= 7)
		{
			if(co2%2==0){
				maghalo.gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else{
				maghalo.gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
		}

			if(Time.time-curtime >= 10.0f)
			{
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
			magged = false;
			curtime2 = 1000000f;
			GameObject halo2 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			maghalo.gameObject.GetComponent<MeshRenderer> ().enabled = false;
			halo2.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
				}
		}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "wall") {
						GetComponent<Rigidbody2D>().AddForce (Vector2.right * -1);
				} 
		if (col.gameObject.tag == "brick" || col.gameObject.tag == "updown") {
			GetComponent<AudioSource>().Play ();
		} 
	}
	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "brick")
		{
			//transform.Translate(0,height,0);
			//rigidbody2D.position += (Vector2.up * height );
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * height * 55);
			}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "puphyper") {
			GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
			Activatepuphyper();
			Destroy(col.gameObject,0);
		}
		if (col.gameObject.tag == "puptele") {
			Activatepuptele();
			Destroy(col.gameObject);
				}
		if (col.gameObject.tag == "pupmag") {
			Activatepupmag();
			Destroy(col.gameObject);
				}
		if (col.gameObject.tag == "pupshield") {
			shield.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			shield.gameObject.GetComponent<MeshRenderer>().enabled = true;
			GameObject halo2 = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo2.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
			curtimeshi = Time.time;
			Destroy(col.gameObject);
				}

		if (score == 10) {
			Social.ReportProgress("CgkI1OiZi54dEAIQAA", 100.0f,(bool success) =>{
				Debug.Log("Scored 10");
			});
				}
		if (score == 25) {
						Social.ReportProgress ("CgkI1OiZi54dEAIQAg", 100.0f, (bool success) => {
								Debug.Log ("Scored 25");
						});
				}
		if (score == 40) {
						Social.ReportProgress ("CgkI1OiZi54dEAIQAw", 100.0f, (bool success) => {
								Debug.Log ("Scored 40");
						});
				}
		if (score == 50) {
					Social.ReportProgress("CgkI1OiZi54dEAIQBQ", 100.0f,(bool success) =>{
						Debug.Log("Scored 50");
					});
		}
		if (score == 75) {
					Social.ReportProgress("CgkI1OiZi54dEAIQBA", 100.0f,(bool success) =>{
						Debug.Log("Scored 75");
					});
				}
		if (score == 100) {
					Social.ReportProgress("CgkI1OiZi54dEAIQCQ", 100.0f,(bool success) =>{
						Debug.Log("Scored 100");
					});
				}
		if (score == 150) {
			Social.ReportProgress("CgkI1OiZi54dEAIQCw", 100.0f,(bool success) =>{
				Debug.Log("Scored 150");
			});
		}
		if (score == 200) {
			Social.ReportProgress("CgkI1OiZi54dEAIQDA", 100.0f,(bool success) =>{
				Debug.Log("Scored 200");
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
		this.gameObject.GetComponent<MeshRenderer>().enabled = true;
		this.gameObject.GetComponent<TrailRenderer> ().enabled = true;
		ballref.gameObject.GetComponent<MeshRenderer>().enabled = false;
		ballref.transform.FindChild("halocontrol").gameObject.GetComponent<TrailRenderer>().enabled = false;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-GetComponent<Rigidbody2D> ().velocity.x,GetComponent<Rigidbody2D> ().velocity.y);
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
		GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
		halo.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
		magged = true;
		maghalo.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		curtime2 = Time.time;
	}
}