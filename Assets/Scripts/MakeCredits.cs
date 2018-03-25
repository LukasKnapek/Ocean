using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCredits : MonoBehaviour {


    public GameObject j;
    // Update is called once per frame
    void Update () {
		if (transform.position.y < -100)
        {
            j.SetActive(true);
        }
	}
}
