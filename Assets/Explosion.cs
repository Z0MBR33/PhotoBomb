using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float radius = 5.0F;
    public float power = 100.0F;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if(hit.gameObject.GetComponent<moveMe>() != null && !hit.gameObject.GetComponent<moveMe>().myRagDoll.activeSelf)
            {
                hit.gameObject.GetComponent<moveMe>().SwitchMode();
                Rigidbody rb = hit.GetComponentInChildren<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);

            }
            

            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
