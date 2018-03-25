using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet : MonoBehaviour {

    public float DegreesPerSecond;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(DegreesPerSecond * Time.deltaTime, DegreesPerSecond * Time.deltaTime, 0);
    }

   

}
