using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	
	public Color defCol;
	public Color selCol; 
	private Material mat;

	public float speed;
	public Rigidbody2D g;
	
	void Start()
	{
		Application.targetFrameRate = 90;
		
		QualitySettings.vSyncCount = 0; 
		//mat = renderer.material;
	}
	void Update()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			g.GetComponent<Rigidbody2D> ().velocity += Vector2.right * 0.25f;
		} 
		else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			g.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,g.GetComponent<Rigidbody2D> ().velocity.y);
		}
		else if (Input.GetKey(KeyCode.RightArrow)) {
			g.GetComponent<Rigidbody2D> ().velocity += Vector2.right * -0.25f;
		}
		else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			g.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,g.GetComponent<Rigidbody2D> ().velocity.y);
		}

	}
	
	void OnTouchDown()
	{
		//mat.color = selCol;
		/*if (g.transform.position.x < 0.5 || g.transform.position.x > 7.5) {
			Debug.Log("OUTSIDE");		
		}
		if (g.transform.position.x >= 0.5 && g.transform.position.x <= 7.5) {
			g.transform.position +=new Vector3(speed , 0, 0);
				}*/
		//Debug.Log (Time.time);
		//g.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * 10000f * (Time.smoothDeltaTime));
		g.GetComponent<Rigidbody2D> ().velocity += Vector2.right * speed;
	}
	void OnTouchUp()
	{
		//mat.color = defCol;
		//g.transform.Translate (-speed, 0, 0);
		g.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,g.GetComponent<Rigidbody2D> ().velocity.y);
		//g.GetComponent<Rigidbody2D> ().velocity += Vector2.right * 10 *-speed ;
	}
	void OnTouchStay()
	{
		//mat.color = selCol;
		/*if (g.transform.position.x < 0.5 || g.transform.position.x > 7.5) {
			Debug.Log("OUTSIDE");		
		}
		if (g.transform.position.x >= 0.5 && g.transform.position.x <= 7.5) {
			g.transform.position +=new Vector3(speed , 0, 0);
		}*/
		//g.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * 10000f * (Time.smoothDeltaTime));
		g.GetComponent<Rigidbody2D> ().velocity += Vector2.right * speed;
	}
	void OnTouchExit()
	{
		//mat.color = defCol;
		//g.transform.Translate (-speed, 0, 0);
		g.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,g.GetComponent<Rigidbody2D> ().velocity.y);
		//g.GetComponent<Rigidbody2D> ().velocity += Vector2.right * 10 * -speed ;
	}
}
