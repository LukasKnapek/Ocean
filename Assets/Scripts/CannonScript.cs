using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {
	
	public int SHOOTING_POWER = 20;
	public int SHOT_GRAVITY = 10;
	public float BALL_SIZE = 2.5f;
	public float EXPLOSION_POWER = 0.05f;
	public float EXPLOSION_RADIUS = 2f;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Fire() {
		print (EXPLOSION_RADIUS + "," + EXPLOSION_POWER);
		GameObject cannonCube = (GameObject) Instantiate (Resources.Load ("CannonCube"));
		cannonCube.transform.localScale = new Vector3 (BALL_SIZE, BALL_SIZE, BALL_SIZE);
		cannonCube.transform.position = transform.position + (transform.forward * 15);
		cannonCube.GetComponent<CannonCubeScript> ().direction = transform.forward;
		cannonCube.GetComponent<CannonCubeScript> ().shot_power = SHOOTING_POWER;
		cannonCube.GetComponent<CannonCubeScript> ().shot_gravity = SHOT_GRAVITY;
		cannonCube.GetComponent<CannonCubeScript> ().explosion_power = EXPLOSION_POWER;
		cannonCube.GetComponent<CannonCubeScript> ().explosion_radius = EXPLOSION_RADIUS;
        if (PlayerManager.SCRAP > 0)
        {
            PlayerManager.SCRAP -= 1;
        }
    }
}
