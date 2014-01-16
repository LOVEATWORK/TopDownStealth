using UnityEngine;
using System.Collections;

public class characterControllerScript : MonoBehaviour {
	
	//Public Vars
	public Camera camera;
	public float speed;
	
	//Private Vars
	private Vector3 mousePosition;
	private Vector3 direction;
	private float distanceFromObject;
	private float t;

	void Start() {

		t = Time.time;

	}

	void FixedUpdate() {
		
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


			// Debug.Log(Vector3.Lerp(transform.position, mousePosition, 10f));

			// transform.Translate(Vector3.Lerp(transform.position, mousePosition, (t - Time.time)));

			transform.position = Vector3.Lerp(transform.position, mousePosition, (t - Time.time));
			// rigidbody2D.velocity = Vector2.Lerp(transform.position, mousePosition, speed);

			// rigidbody2D.velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		}//End Move Towards If Case
		
	}//End Fire3 If case
}

