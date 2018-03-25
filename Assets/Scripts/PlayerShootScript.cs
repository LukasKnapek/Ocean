using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

	private int shootingDelay = 0;
	public int SHOOTING_SPEED = 2;

	private CannonScript cannonLeft;
	private CannonScript cannonRight;

	// Use this for initialization
	void Start () {
		cannonLeft = GameObject.Find ("CannonLeft").GetComponent<CannonScript>();
		cannonRight = GameObject.Find ("CannonRight").GetComponent<CannonScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("e") && shootingDelay >= SHOOTING_SPEED * 60) {
			cannonRight.Fire ();
			shootingDelay = 0;
		}
		if (Input.GetKey ("q") && shootingDelay >= SHOOTING_SPEED * 60) {
			cannonLeft.Fire ();
			shootingDelay = 0;
		}
		shootingDelay += 1;
	}
}
