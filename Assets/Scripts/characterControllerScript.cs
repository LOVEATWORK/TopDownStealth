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

	/*
	//Public Vars
	public Camera camera;
	public float speed;

	//Private Vars
	private Vector3 mousePosition;
	private Vector3 direction;
	private float distanceFromObject;
	private float t;
	private Transform myTransform;
	private Vector3 destinationPosition;

	void Start() {

		t = Time.time;
		myTransform = transform;
		destinationPosition = transform.position;

	}

	void Update() {
		
		if (Input.GetButton("Fire1")){
			
			//Grab the current mouse position on the screen
			mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));
			
			//Rotates toward the mouse
			rigidbody2D.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x))*Mathf.Rad2Deg - 90);
			
			//Judge the distance from the object and the mouse
			distanceFromObject = (Input.mousePosition - camera.WorldToScreenPoint(transform.position)).magnitude;

			// direction = transform.rotation;

			//Move towards the mouse
			// rigidbody2D.AddForce(direction * speed * distanceFromObject * Time.deltaTime);
			// rigidbody2D.AddForce(new Vector2(10f, 10f));

			destinationPosition = mousePosition;

			// Debug.Log(Vector3.Lerp(transform.position, mousePosition, 10f));

			// transform.Translate(Vector3.Lerp(transform.position, mousePosition, (t - Time.time)));

			myTransform.position = Vector2.MoveTowards(myTransform.position, destinationPosition, speed * Time.deltaTime);
			// rigidbody2D.velocity = Vector2.Lerp(transform.position, mousePosition, speed);

			// rigidbody2D.velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		}//End Move Towards If Case
		
	}//End Fire3 If case

	*/
}

