using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	public float explosionRadius;
	public float explosionPower;
	private SphereCollider col;
	private ParticleSystem ps;

	private int aliveFrames;

	// Use this for initialization
	void Start () {
		col = GetComponent<SphereCollider> ();
		ps = GetComponentInChildren<ParticleSystem> ();
		aliveFrames = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		if (col.radius < explosionRadius) {
			col.radius += explosionPower;
		} else {
			col.radius = 0f;
		}

		if (aliveFrames/60 >= ps.main.duration) {
			Destroy (gameObject);
		}
		aliveFrames += 1;
	}
}
