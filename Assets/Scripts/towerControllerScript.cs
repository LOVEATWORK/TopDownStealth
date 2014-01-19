using UnityEngine;
using System.Collections;

public class towerControllerScript : MonoBehaviour {

	public Transform areaWatchStart;
	public Transform areaWatchEnd;
	public float rotationSpeed = 2f;
	public float agression = 5f;
	public float sightRadius = 5;
	public Collider2D spotted;
	public LayerMask playerLayer;

	//values for internal use
	private float _lookRotation;
	private Vector3 _direction;
	private GameObject target;

	private Vector3 targetPoint;
	private Quaternion targetRotation;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {	

		Raycasting ();

		if (spotted != null) {

			target = spotted.gameObject;

			float angle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
			float str = Mathf.Min(agression * Time.deltaTime, 1);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), str);


		} else {
			Spin ();	
		}
	}

	void Raycasting() {
		Debug.DrawLine (areaWatchStart.position, areaWatchEnd.position, Color.white);
		spotted = Physics2D.OverlapCircle (transform.position, sightRadius, playerLayer);
	}

	void Spin() {
		transform.Rotate (0, 0, 60 * (rotationSpeed * Time.deltaTime));
	}

}
