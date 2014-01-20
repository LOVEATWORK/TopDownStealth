using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float sightRadius = 5f;
	public LayerMask playerLayer;
	public float rotationSpeed = 0.5f;
	public float speed = 0.5f;

	private Collider2D spotted;
	private bool pointingAtPlayer = false;

	// Update is called once per frame
	void Update () {
	
		Raycasting ();

		if (spotted) 
		{

			Debug.DrawLine (transform.position, spotted.gameObject.transform.position, Color.green);
			StartCoroutine(RotateTowardsObject(spotted.gameObject.transform, rotationSpeed));
		
			if (pointingAtPlayer) {

				// TODO Move object towards player

				// transform.Translate(spotted.gameObject.transform.position);
			
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, spotted.gameObject.transform.position, step); 

			}
		
		}


	}

	
	void Raycasting() {
		spotted = Physics2D.OverlapCircle (transform.position, sightRadius, playerLayer);
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
