using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilWellScript : MonoBehaviour {

	public int oilAmount;
	public bool trackOilRemainder = false;
	private ParticleSystem.EmissionModule emission;


	// Use this for initialization
	void Start () {
		oilAmount = Random.Range (7, 40) * 5;

		emission = GetComponentInChildren<ParticleSystem> ().emission;
		emission.rateOverTime = oilAmount / 15;
	}
	
	// Update is called once per frame
	void Update () {
		if (oilAmount <= 0)
			Destroy(this.gameObject);

		if (trackOilRemainder) {
			emission.rateOverTime = oilAmount / 15;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			trackOilRemainder = true;
			PlayerManager.oilSource = this;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			trackOilRemainder = false;
			PlayerManager.oilSource = null;
		}
	}
}
