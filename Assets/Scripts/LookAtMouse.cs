using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 upAxis = new Vector3(0,0,-1);
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = transform.position.z;
		Vector3 mouseWorldSpace = Camera.mainCamera.ScreenToWorldPoint(mouseScreenPosition);
		transform.LookAt(mouseWorldSpace, upAxis);
		transform.eulerAngles = new Vector3(0,0,-transform.eulerAngles.z - 90);
	}
}
