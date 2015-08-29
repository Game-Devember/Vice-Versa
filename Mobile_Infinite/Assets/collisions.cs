using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class collisions : MonoBehaviour {
	public Color trailcolor;
	public float height;
	public GameObject g;
	public GameObject ballref;
	private int score;
	public Text st;
	public Text coincounter;
	public GameObject cam = null;

	public Color c1;
	public Color c2;
	private int i=0;
	//private int coincount = 0;
	private Collider2D c;
	private float beforepup;
	private bool hypered = false;
	private float curtime = 1000000f;
	private float curtime2 = 1000000f;
	private int co;
	private int co2;
	public GameObject controlleft;
	public GameObject controlright;

	public GameObject maghalo;
	public bool magged = false;

	//private Transform t;
	void Start()
	{
		PlayerPrefs.SetInt("COINCOUNT",0);
		i = 0;
		st.color = c1;
		Physics2D.IgnoreCollision (GetComponent<Collider2D>(), g.GetComponent<Collider2D>());
		//transform.Translate (0.17f, 0, 0);
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
		st.text = score.ToString ();
				if (hypered) {
						float c1 = ballref.gameObject.GetComponent <TrailRenderer> ().startWidth;
						ballref.gameObject.GetComponent <TrailRenderer> ().startWidth = Mathf.Lerp(c1,0,Time.deltaTime*0.5f);
						float c2 = ballref.gameObject.GetComponent <TrailRenderer> ().endWidth;
						ballref.gameObject.GetComponent <TrailRenderer> ().endWidth = Mathf.Lerp(c2,0,Time.deltaTime*0.5f);
						float c3 = ballref.gameObject.GetComponent<TrailRenderer>().time;
						ballref.gameObject.GetComponent<TrailRenderer>().time = Mathf.Lerp(c3,0,Time.deltaTime);

						if (/*this.transform.position.x > 0 && */this.transform.position.x < 0.55f) {
								//GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 7000f);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x,GetComponent<Rigidbody2D>().velocity.y);
						}
						if (this.transform.position.x > 7.7f /*&& this.transform.position.x < 8.2f*/) {
								//GetComponent<Rigidbody2D> ().AddForce (Vector2.right * -7000f);
				GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x,GetComponent<Rigidbody2D>().velocity.y);
						}
				
						if (this.GetComponent<Rigidbody2D> ().velocity.y <= 0 && hypered) {
								c.isTrigger = false;
				ballref.gameObject.GetComponent <TrailRenderer> ().enabled = false;
								hypered = false;
						}
				}
		co++;
			if(Time.time-curtime >= 7)
			{
					if(co%10!=0){
				this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else{
				this.gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
			}
		co2++;
		if(Time.time-curtime2 >= 7)
		{
			if(co2%10!=0){
				maghalo.gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else{
				maghalo.gameObject.GetComponent<MeshRenderer>().enabled = true;
			}
		}

			if(Time.time-curtime >= 10.0f)
			{
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			ballref.gameObject.GetComponent<MeshRenderer>().enabled = true;
				curtime = 1000000f;
			//this.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0);
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
		//t = transform.position
		if (col.gameObject.tag == "wall") {
						GetComponent<Rigidbody2D>().AddForce (Vector2.right * -1);
				} 
		if (col.gameObject.tag == "brick" || col.gameObject.tag == "updown") {
			GetComponent<AudioSource>().Play ();
		} 
		/*GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
		halo.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);*/
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
				/*if (col.gameObject.tag == "score") {
						Destroy (col.gameObject);
						score++;
						//Debug.Log (score);
				}*/
		/*if (col.gameObject.tag == "coin") {
			coincount++;
			//coincount++;
			coincounter.text = coincount.ToString();
			Destroy(col.gameObject);
		}*/
		if (col.gameObject.tag == "puphyper") {
			GameObject halo = Instantiate(Resources.Load("Prefabs/halocontrol")) as GameObject;
			halo.transform.Translate(-transform.position.x,transform.position.y,transform.position.z);
			Activatepuphyper();
			/*for(int i=0;i<1000;i++)
			{
				Debug.Log("waiting"+i.ToString());
			}*/
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
		return score;
	}

	public void Activatepuphyper()
	{
		hypered = true;
		c = this.gameObject.GetComponent<Collider2D>();
		c.isTrigger = true;
		ballref.gameObject.GetComponent <TrailRenderer> ().startWidth = 0.7f;
		ballref.gameObject.GetComponent <TrailRenderer> ().endWidth = 0.7f;
		ballref.gameObject.GetComponent <TrailRenderer> ().time = 0.5f;
		//beforepup = cam.transform.position.y;
		ballref.gameObject.GetComponent <TrailRenderer>().enabled = true;
		GetComponent<Rigidbody2D>().AddForce( Vector2.up * 10000);
		/*for(int i =0;i<1000;i++)
		{
			Debug.Log(Time.time);
		}*/

		//this.gameObject.GetComponent<TrailRenderer>
	}
	public void Activatepuptele()
	{
		this.gameObject.GetComponent<MeshRenderer>().enabled = true;
		ballref.gameObject.GetComponent<MeshRenderer>().enabled = false;
		//GetComponent<Rigidbody2D>().AddForce( Vector2.up * 2000f);
		//this.gameObject.GetComponent<Collider2D> ().isTrigger = true;
		//this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 3.0f,this.transform.position.z);
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
		//Debug.Log("FU");
	}
}