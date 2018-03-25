using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIndicatorScript : MonoBehaviour {

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		var wantedPos = Camera.main.WorldToViewportPoint (target.position);
		transform.position = wantedPos; 
	}
}
