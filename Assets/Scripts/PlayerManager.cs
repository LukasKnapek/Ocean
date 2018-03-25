using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public static int OIL_LEFT = 300;
	public static bool canDrillOil = false;
	public static OilWellScript oilSource;

	public static int SCRAP = 0;
	public static bool canCollectScrap = false;
	public static ScrapSourceScript scrapSource;

	public static Rigidbody body;

	private int lastScrap = 0;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		UIManager.UpdateOilValue ();
		UIManager.UpdateScrapValue ();
		if (OIL_LEFT <= 0) {
			body.useGravity = true;
			GetComponent<PlayerMove> ().enabled = false;
		}


		if (SCRAP > lastScrap) {

			foreach (CannonScript cannon in GetComponentsInChildren<CannonScript> ()) {
				cannon.BALL_SIZE = 1.5f + (SCRAP / 20);
				cannon.EXPLOSION_POWER = 0.05f + (SCRAP / 200.0f);
				cannon.EXPLOSION_RADIUS = 2f + (SCRAP / 10.0f);

			}
				
		}
		lastScrap = SCRAP;
	}
}
