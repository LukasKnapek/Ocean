using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAimScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		GetComponentInParent<EnemyMoveScript> ().OnCollisionEnter(collision);
	}

	void OnCollisionExit(Collision collision) {
		GetComponentInParent<EnemyMoveScript> ().OnCollisionExit(collision);
	}

	void OnTriggerEnter(Collider other) {
		GetComponentInParent<EnemyMoveScript> ().OnTriggerEnter(other);
	}
}
