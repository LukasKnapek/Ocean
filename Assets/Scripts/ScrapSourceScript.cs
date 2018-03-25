using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapSourceScript : MonoBehaviour {

	public int scrapAmount;
	public bool trackRemainder = false;
	private ParticleSystem.EmissionModule emission;

	// Use this for initialization
	void Start () {
		scrapAmount = Random.Range (20, 60) * 2;

		emission = GetComponentInChildren<ParticleSystem> ().emission;
		emission.rateOverTime = scrapAmount;
	}
	
	// Update is called once per frame
	void Update () {
		if (scrapAmount <= 0)
			Destroy(this.gameObject);

		if (trackRemainder) {
			emission.rateOverTime = scrapAmount;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			trackRemainder = true;
			PlayerManager.scrapSource = this;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			trackRemainder = false;
			PlayerManager.scrapSource = null;
		}
	}
}
