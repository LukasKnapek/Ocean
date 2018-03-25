using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float HealthLoss;
    public float Health = 2;
    // Use this for initializatiom
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Health -= HealthLoss;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            GameObject explosion = (GameObject)Instantiate(Resources.Load("Explosion"));
            explosion.GetComponent<ExplosionScript>().explosionRadius = 5;
            explosion.transform.position = transform.position;
            Destroy(gameObject);

        }
    }
}
