using UnityEngine;
using System.Collections;

public class towerControllerScript : MonoBehaviour {

	public float rotationSpeed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		Spin ();
	}

	void Spin() {
		transform.Rotate (0, 0, 60 * (rotationSpeed * Time.deltaTime));
	}

}
