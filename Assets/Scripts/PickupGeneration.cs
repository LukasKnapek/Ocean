using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGeneration : MonoBehaviour {

	public int N_OIL_SOURCES = 10;    
	public int N_SCRAP_SOURCES = 5;    


	// Use this for initialization
	void Start () {
		Renderer sandPlaneRenderer = GetComponent<Renderer> ();
		Vector3 sandPlaneCenter = sandPlaneRenderer.bounds.center;
		float placingWidth = sandPlaneRenderer.bounds.size.x / 2;
		float placingHeight = sandPlaneRenderer.bounds.size.z / 2;

		print (sandPlaneRenderer.bounds.size.x + "," + sandPlaneRenderer.bounds.size.z);

		for (int i = 0; i < N_OIL_SOURCES; i++) {
			float pickupX = Random.Range (-placingWidth, placingWidth);
			float pickupZ = Random.Range (-placingHeight, placingHeight);

			Vector3 tempPickupPos = new Vector3 (pickupX, 20, pickupZ);
			RaycastHit hit;
			Physics.Raycast (tempPickupPos, Vector3.down, out hit, 100);

			float pickupY = hit.point.y + 0.1f;

			GameObject source = (GameObject) Instantiate(Resources.Load("OilSource"));
			source.transform.position = new Vector3(pickupX, pickupY, pickupZ);
		}

		for (int i = 0; i < N_SCRAP_SOURCES; i++) {
			float pickupX = Random.Range (-placingWidth, placingWidth);
			float pickupZ = Random.Range (-placingHeight, placingHeight);

			Vector3 tempPickupPos = new Vector3 (pickupX, 20, pickupZ);
			RaycastHit hit;
			Physics.Raycast (tempPickupPos, Vector3.down, out hit, 100);

			float pickupY = hit.point.y + 0.1f;

			GameObject source = (GameObject) Instantiate(Resources.Load("ScrapSource"));
			source.transform.position = new Vector3(pickupX, pickupY, pickupZ);
			//source.transform.rotation.
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
