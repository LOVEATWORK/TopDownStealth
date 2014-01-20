using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	// Designer variables
	public int damage = 1;
	public bool isEnemyShot = false;
	public float TTL = 20;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, TTL);

	}
}
