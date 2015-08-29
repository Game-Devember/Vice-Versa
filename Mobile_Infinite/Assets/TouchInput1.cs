using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput1 : MonoBehaviour {

	public LayerMask touchInputMask;
	
	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit h;
	// Update is called once per frame
	void Update () 
	{

#if UNITY_EDITOR
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) 
		{
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			
				Ray r = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
				
				
				if (Physics.Raycast (r, out h, touchInputMask)) {
					
					GameObject recipient = h.transform.gameObject;
					touchList.Add(recipient);
					
					if (Input.GetMouseButtonDown(0)) {
						recipient.SendMessage ("OnTouchDown", h.point, SendMessageOptions.DontRequireReceiver);
					}
					if ( Input.GetMouseButtonUp(0)) {
						recipient.SendMessage ("OnTouchUp", h.point, SendMessageOptions.DontRequireReceiver);
					}
					if (Input.GetMouseButton(0)) {
						recipient.SendMessage ("OnTouchStay", h.point, SendMessageOptions.DontRequireReceiver);
					}
				}
			
			foreach(GameObject g in touchesOld)
			{
				if(!touchList.Contains(g))
				{
					g.SendMessage ("OnTouchExit", h.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
#endif

		if (Input.touchCount > 0) 
		{
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
			
			foreach (Touch t in Input.touches) 
			{
				Ray r = GetComponent<Camera>().ScreenPointToRay (t.position);
				if (Physics.Raycast (r, out h, touchInputMask)) 
				{
					
					GameObject recipient = h.transform.gameObject;
					touchList.Add(recipient);
					
					if (t.phase == TouchPhase.Began) {
						recipient.SendMessage ("OnTouchDown", h.point, SendMessageOptions.DontRequireReceiver);
					}
					if (t.phase == TouchPhase.Ended) {
						recipient.SendMessage ("OnTouchUp", h.point, SendMessageOptions.DontRequireReceiver);
					}
					if (t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Moved) {
						recipient.SendMessage ("OnTouchStay", h.point, SendMessageOptions.DontRequireReceiver);
					}
					if (t.phase == TouchPhase.Canceled) {
						recipient.SendMessage ("OnTouchExit", h.point, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
			foreach(GameObject g in touchesOld)
			{
				if(!touchList.Contains(g))
				{
					g.SendMessage ("OnTouchExit", h.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
