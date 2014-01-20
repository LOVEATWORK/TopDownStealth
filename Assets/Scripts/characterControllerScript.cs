using UnityEngine;
using System.Collections;

public class characterControllerScript : MonoBehaviour {
	
	public float moveSpeed = 10f;
	public float turnSpeed = 4f;
	private Vector3 moveDirection;
	private Vector3 moveToward;

	void Start() {

		// moveDirection = Vector3.right;

	}
	
	void Update() {

		Vector3 currentPosition = transform.position;

		if (Input.GetButton ("Fire2")) {

			moveDirection = getMoveDirection(Input.mousePosition);
			moveDirection.Normalize();
		
			RotateToMouseClick (moveDirection.x, moveDirection.y);

			Vector3 target = moveDirection * moveSpeed + currentPosition;

			if (Mathf.Round(transform.position.x) != Mathf.Round(moveToward.x) && Mathf.Round(transform.position.y) != Mathf.Round(moveToward.y)) {
				transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);		
			} else {
				// rigidbody2D.velocity = Vector3.zero;

			}
		}

		if (Input.GetButtonDown ("Fire1")) {
		
			moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			moveDirection = getMoveDirection(Input.mousePosition);
			// moveDirection.Normalize();

			RotateToMouseClick (moveDirection.x, moveDirection.y);

			WeaponScript weapon = GetComponent<WeaponScript>();

			if (weapon != false)
				weapon.Attack(false);


		
		}
	
	}

	void RotateToMouseClick(float x, float y) {

		float targetAngle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
		// transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Euler (0, 0, targetAngle);


	}

	Vector3 getMoveDirection(Vector3 target) {

		moveToward = Camera.main.ScreenToWorldPoint(target);
		moveDirection = moveToward - transform.position;
		moveDirection.z = 0;

		return moveDirection;

	}
}

