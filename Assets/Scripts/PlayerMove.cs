using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


	public float MAX_SPEED = 40;
	public float STEERING_SPEED = 1.5f;
	public float ACCELERATION = 3.5f;
	public float PLAYER_GRAVITY = 400.0f;
	public Vector3 MASS_CENTER = new Vector3(0,-10,0);
	public int OIL_BURN_RATE = 5;
	public int SALVAGE_DELAY = 20;

	private int engine_use = 0;
	private Vector3 direction;
	private Rigidbody body;
	private bool isGrounded;
	private int salvageDelayFrames = 0;



	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody>();
		body.centerOfMass = MASS_CENTER;

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("p")) {
		}

		if (Input.GetKey ("a")) {
			transform.Rotate (0,-STEERING_SPEED, 0);
		}
		else if (Input.GetKey("d")) {
			transform.Rotate(0,STEERING_SPEED,0);
		}			
		if (isGrounded) {
			direction = transform.forward;
			if (Input.GetKey ("w")) {
				if (body.velocity.magnitude < MAX_SPEED) {
					body.velocity += (direction * Input.GetAxis ("Vertical") * ACCELERATION);
				} else {
					body.velocity = direction * MAX_SPEED * Input.GetAxis ("Vertical");
				}
				engine_use++;
			}
			else if (Input.GetKey ("s")) {
				if (body.velocity.magnitude < MAX_SPEED) {
					body.velocity += (direction * Input.GetAxis ("Vertical") * ACCELERATION);
				} else {
					body.velocity = direction * MAX_SPEED * Input.GetAxis ("Vertical");
				}
				engine_use++;
			}

			if (engine_use >= 60) {
				engine_use = 0;
				PlayerManager.OIL_LEFT -= OIL_BURN_RATE;
				UIManager.UpdateOilValue ();
			}
		}

		if (PlayerManager.oilSource != null) {
			if (Input.GetKey(KeyCode.Space)) {
				if (salvageDelayFrames > SALVAGE_DELAY) {
					salvageDelayFrames = 0;
					PlayerManager.OIL_LEFT += 5;
					PlayerManager.oilSource.oilAmount -= 5;
					UIManager.UpdateOilValue ();
				}
				salvageDelayFrames++;
			}
		}

		if (PlayerManager.scrapSource != null) {
			if (Input.GetKey(KeyCode.Space)) {
				if (salvageDelayFrames > SALVAGE_DELAY) {
					salvageDelayFrames = 0;
					PlayerManager.SCRAP += 2;
					PlayerManager.scrapSource.scrapAmount -= 2;
					UIManager.UpdateOilValue ();
				}
				salvageDelayFrames++;
			}
		}

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}

	void FixedUpdate() {
		body.AddForce(Vector3.down * PLAYER_GRAVITY, ForceMode.Acceleration);
	}

}
