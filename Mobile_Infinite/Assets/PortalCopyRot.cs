using UnityEngine;
using System.Collections;

public class PortalCopyRot : MonoBehaviour {

	public GameObject portalref;
	void Update () {
		transform.rotation = portalref.transform.rotation;
		transform.position = new Vector3(-portalref.transform.position.x,transform.position.y,transform.position.z);
	}
}
