using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour {

	public float moveSpeed = 3f;
	public float gridSize = 1f;
	public bool facingRight = true;
	public bool facingUp = false;

	public enum Orientation {
		Horizontal,
		Vertical
	};
	public Orientation gridOrientation = Orientation.Vertical;
	public bool allowDiagonals = false;
	private bool correctDiagonalSpeed = true;
	private Vector2 input;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;
	
	public void Update() {
			if (!isMoving) {
					input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
					if (!allowDiagonals) {
							if (Mathf.Abs (input.x) > Mathf.Abs (input.y)) {
									input.y = 0;
							} else {
									input.x = 0;
							}
					}
		
					if (input != Vector2.zero) {
						StartCoroutine (move (transform));
					}
			}

			if (Input.GetButtonDown ("Fire1")) {
		
					// Vector3 moveToward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
					// Vector3 moveDirection = getMoveDirection (Input.mousePosition);
					// moveDirection.Normalize();
		
					// RotateToMouseClick (moveDirection.x, moveDirection.y);
		
					WeaponScript weapon = GetComponent<WeaponScript> ();

					if (weapon != false)
							weapon.Attack (false);

			}
	}
	
	void RotateToMouseClick(float x, float y) {
		
		float targetAngle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
		// transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Euler (0, 0, targetAngle);
		
		
	}
	
	Vector3 getMoveDirection(Vector3 target) {
		
		Vector3 moveToward = Camera.main.ScreenToWorldPoint(target);
		Vector3 moveDirection = moveToward - transform.position;
		moveDirection.z = 0;
		
		return moveDirection;
		
	}
	
	public IEnumerator move(Transform transform) {
		isMoving = true;
		startPosition = transform.position;
		t = 0;
		
		if(gridOrientation == Orientation.Horizontal) {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
		} else {
			endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                          startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
		}
		
		if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
			factor = 0.7071f;
		} else {
			factor = 1f;
		}
		
		while (t < 1f) {
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
		
		isMoving = false;
		yield return 0;
	}

	void Flip(Orientation orient) {

		// TODO: Reset angles to right-angles before anything elses

		if (orient == Orientation.Horizontal) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

		if (orient == Orientation.Vertical) {
			
			facingUp = !facingUp;
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;

		}
	}
}