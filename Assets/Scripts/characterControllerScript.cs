using UnityEngine;
using System.Collections;

public class characterControllerScript : MonoBehaviour {
	
	public float moveSpeed = 10f;
	public float turnSpeed = 4f;
	private Vector3 moveDirection;

	void Start() {

		// moveDirection = Vector3.right;

	}
	
	void Update() {

		Vector3 currentPosition = transform.position;

		if (Input.GetButton ("Fire1")) {
				
			Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize();

		}

		float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);

		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);
	}
}

