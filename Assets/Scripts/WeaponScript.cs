using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	// Designer variables

	public Transform shotPrefab;
	public float shootingRate = 0.25f;
	public float shootingRange = 0.5f;

	private float shotCooldown;



	// Use this for initialization
	void Start () {
	
		shotCooldown = 0f;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (shotCooldown > 0)
			shotCooldown -= Time.deltaTime;

	}

	public void Attack(bool isEnemy) {

		if (CanAttack) {

			shotCooldown = shootingRate;
			var shotTransform = Instantiate(shotPrefab) as Transform;

			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

			if (shot != null)
				shot.isEnemyShot = isEnemy;

			shot.TTL = shootingRange;

			// Make shot move in the correct direction
			BasicMoveScript move = shotTransform.gameObject.GetComponent<BasicMoveScript>();
			if (move != null)
				move.direction = this.transform.right;

		
		}

	}

	public bool CanAttack {

		get {
			return shotCooldown <= 0f;
		}
	}
}
