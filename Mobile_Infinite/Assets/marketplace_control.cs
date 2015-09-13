using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class marketplace_control : MonoBehaviour {

	public Text soon;
	public Color cdef;
	private Color c;
	void Start()
	{
		c = new Color (cdef.r,cdef.g,cdef.b,0);
		soon.color = c;
	}
	// Update is called once per frame
	void Update () {
		soon.color = Color.Lerp (soon.color, c, Time.deltaTime * 2);
	}
	void OnTouchDown()
	{
		soon.color = cdef;
	}
}
