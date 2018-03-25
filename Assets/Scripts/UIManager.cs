using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private static Text oilDisplayText;
	private static Text scrapDisplayText;

	// Use this for initialization
	void Start () {
		oilDisplayText = transform.Find ("OilDisplay/OilText").GetComponent<Text>();
		scrapDisplayText = transform.Find ("ScrapDisplay/ScrapText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void UpdateOilValue() {
		oilDisplayText.text = "Oil: " + PlayerManager.OIL_LEFT;
	}

	public static void UpdateScrapValue() {
		if (PlayerManager.SCRAP < 20) {
			scrapDisplayText.text = "Scrap: " + PlayerManager.SCRAP + "/" + 20;
		} else if (PlayerManager.SCRAP < 50) {
			scrapDisplayText.text = "Scrap: " + PlayerManager.SCRAP + "/" + 50;
		} else if (PlayerManager.SCRAP < 75) {
			scrapDisplayText.text = "Scrap: " + PlayerManager.SCRAP + "/" + 75;
		} else if (PlayerManager.SCRAP < 100) {
			scrapDisplayText.text = "Scrap: " + PlayerManager.SCRAP + "/" + 100;
		} else {
			scrapDisplayText.text = "MAXIMUM SCRAP POWER!";
		}
	}
}
