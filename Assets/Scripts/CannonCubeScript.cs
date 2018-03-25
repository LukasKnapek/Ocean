using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCubeScript : MonoBehaviour {

	public Vector3 direction;
	public float shot_power;
	public float shot_gravity;
	public float explosion_power;
	public float explosion_radius;

	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		body.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * shot_power;
	}

	void FixedUpdate() {
		body.AddForce (Vector3.down * shot_gravity, ForceMode.Acceleration);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Ground" || collision.collider.tag == "Enemy" || collision.collider.tag == "Player") {
			Vector3 endPos = transform.position;
			Destroy (gameObject);
			GameObject explosion = (GameObject) Instantiate(Resources.Load("Explosion"));
			explosion.GetComponent<ExplosionScript> ().explosionRadius = 5;
			explosion.GetComponent<ExplosionScript> ().explosionPower = explosion_power;
			explosion.GetComponent<ExplosionScript> ().explosionRadius = explosion_radius;
			explosion.transform.position = endPos;

			if (collision.collider.tag == "Enemy") {
				collision.gameObject.GetComponent<EnemyMoveScript> ().gotHit = true;
			}
		}
	}
}
