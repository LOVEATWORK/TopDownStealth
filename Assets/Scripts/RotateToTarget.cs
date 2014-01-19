using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {

	public float rotationSpeed = 4;
	public Transform target;
	public float sightRadius;
	public LayerMask playerLayer;

	public GameObject shotIndicator;

	public float strength = 0.5f;

	private Quaternion targetRotation;
	private float str;
	private Collider2D spotted;
	private bool pointingAtPlayer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Raycasting ();

		if (spotted) {

			// Debugging spotting
			Debug.DrawLine (transform.position, spotted.gameObject.transform.position, Color.green);
			StartCoroutine(RotateTowardsObject(spotted.gameObject.transform, strength));

			if (pointingAtPlayer)
				shotIndicator.SetActive(true);

		} else {

			shotIndicator.SetActive(false);
			pointingAtPlayer = false;
			Spin ();		
		
		}
	}

	void Raycasting() {
		spotted = Physics2D.OverlapCircle (transform.position, sightRadius, playerLayer);

	}

	void Spin() {
		transform.Rotate (0, 0, 60 * (rotationSpeed * Time.deltaTime));
	}

	IEnumerator RotateTowardsObject(Transform rotateTowards, float duration) {

		Vector3 playerPos = rotateTowards.position;
		
		playerPos.x = playerPos.x - transform.position.x;
		playerPos.y = playerPos.y - transform.position.y;
		
		float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;

		float startTime = Time.time;
		while (Time.time < startTime + duration) {				
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), (Time.time - startTime)/duration);
			yield return null;
		}

		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
		pointingAtPlayer = true;
	}

}
