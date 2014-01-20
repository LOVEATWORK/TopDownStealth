using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	// Designer variables
	public int HP = 1;
	public bool isEnemy = true;
	public Transform deathPrefab;

	void OnTriggerEnter2D(Collider2D collider){

		// Is this a shot?
		ShotScript shot = collider.gameObject.GetComponent<ShotScript> ();

		if (shot != null) {
				
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy) {

				HP -= shot.damage;

				// Destroy shot on hit
				Destroy(shot.gameObject);

				if (HP <= 0) {
					Kill();
				}
			}
		}
	}

	void Kill() {

		var deathTransform = Instantiate(deathPrefab) as Transform;
		deathTransform.position = transform.position;
		deathTransform.rotation = transform.rotation;

		Destroy(gameObject);
	}
}
