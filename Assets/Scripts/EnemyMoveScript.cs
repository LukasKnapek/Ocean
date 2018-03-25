using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

	public float MAX_SPEED = 20;
	public float STEERING_SPEED = 1.5f;
	public float ACCELERATION = 3.5f;
	public float ENEMY_GRAVITY = 20.0f;
	public Vector3 MASS_CENTER = new Vector3(0,-10,0);
	public float SHOOTING_SPEED = 1f;

	private Vector3 direction;
	private Rigidbody body;
	private bool isGrounded;
	private Transform playerTransform;
	private GameObject player;
	private CannonScript cannon;
	private int reloadFrames;

	public bool gotHit = false;
	private int hitDuration = 0;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody>();
		body.centerOfMass = MASS_CENTER;
		playerTransform = GameObject.Find ("Player").transform;
		player = (GameObject)GameObject.Find ("Player");
		cannon = GetComponentInChildren<CannonScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gotHit) {
			if (isGrounded) {
				direction = transform.forward;

				float distance = Vector3.Distance (transform.position, playerTransform.position);

				if (distance > 200) {
					Quaternion targetRotation = Quaternion.LookRotation (playerTransform.position - transform.position);
					transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 0.05f);
				}
				else {
					Vector3 firingPosition = transform.position + new Vector3 (0, 0, 900);
					Quaternion targetRotation = Quaternion.LookRotation (playerTransform.position - firingPosition);
					transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, 0.05f);
				}

				if (body.velocity.magnitude < MAX_SPEED) {
					body.velocity += (direction * ACCELERATION);
				} else {
					body.velocity = direction * MAX_SPEED;
				}
			}
		} else {
			if (hitDuration >= 120) {
				hitDuration = 0;
				gotHit = false;
			}
			hitDuration++;
		}

		reloadFrames++;

	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	public void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Ground") {
			isGrounded = false;
		}

	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" && reloadFrames >= SHOOTING_SPEED * 60) {
			cannon.Fire ();
			reloadFrames = 0;
		}
	}

	void FixedUpdate() {
		body.AddForce(Vector3.down * ENEMY_GRAVITY, ForceMode.Acceleration);
	}
}
