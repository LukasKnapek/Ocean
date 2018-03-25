using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			Camera.main.orthographicSize -= 15;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			Camera.main.orthographicSize += 15;
		}
	}
}
