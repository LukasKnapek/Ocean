using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public float HealthLoss;
    public float Health = 10;
    public RectTransform HealthBoxUI;
    // Use this for initializatiom
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Health -= HealthLoss;
        }
    }

    // Update is called once per frame
    void Update () {
        
        HealthBoxUI.sizeDelta = new Vector2(Health*50,30);

		if (Health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
