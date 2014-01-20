using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	// Designer variables
	public int HP = 1;
	public bool isEnemy = true;
	public Transform deathSprite;

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
					// DIE
					Kill();

				}
			}

		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Kill() {


		Destroy(gameObject);

	}
}
