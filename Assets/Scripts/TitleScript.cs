using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour {

    private RectTransform rectTransform;
    
    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
    }

	// Update is called once per frame
	void Update () {
        rectTransform.sizeDelta = new Vector2(((Mathf.Sin(Time.time)+5)*0.1f)*100, ((Mathf.Sin(Time.time) + 5) * 0.25f) * 100);
	}
}
