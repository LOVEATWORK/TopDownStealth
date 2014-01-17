using UnityEngine;
using System.Collections;

public class towerControllerScript : MonoBehaviour {

	public Transform areaWatchStart;
	public Transform areaWatchEnd;
	public float rotationSpeed = 2f;
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

			//find the vector pointing from our position to the target
			// _direction = (player.position - transform.position).normalized;

			//create the rotation we need to be in to look at the target
			// _lookRotation = Vector3.Angle(transform.position, player.position);

			// Debug.Log(Mathf.Acos(Vector3.Dot(transform.position.normalized, player.position.normalized)));

			// targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
			// targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up);
			// transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

			
			
			//rotate us over time according to speed until we are in the required rotation
			// transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, _lookRotation), Time.deltaTime * rotationSpeed);
			// Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);

		} else {
			Spin ();	
		}
	}

	void Raycasting() {
		Debug.DrawLine (areaWatchStart.position, areaWatchEnd.position, Color.white);
		spotted = Physics2D.OverlapCircle (transform.position, sightRadius, playerLayer);

		Debug.Log (spotted);

	}

	void Spin() {
		transform.Rotate (0, 0, 60 * (rotationSpeed * Time.deltaTime));
	}

}
