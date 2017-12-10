using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeShutterMotion : MonoBehaviour {
    public GameObject upperShutter;
    public GameObject lowerShutter;
    private bool movedown = true;
    private bool moveup = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (upperShutter.transform.position.y > 10 && movedown)
            upperShutter.transform.Translate(new Vector3(0.0f, 0.0f, -0.2f));
        else
            movedown = false;
        if (lowerShutter.transform.position.y < -10 && moveup)
            lowerShutter.transform.Translate(new Vector3(0.0f, 0.0f, 0.2f));
        else
            moveup = false;

        if (!movedown)
            upperShutter.transform.Translate(new Vector3(0.0f, 0.0f, 0.2f));
        if (!moveup)
        {
            lowerShutter.transform.Translate(new Vector3(0.0f, 0.0f, -0.2f));
        }
        if (!moveup && !movedown && (!upperShutter.GetComponent<Renderer>().isVisible || !lowerShutter.GetComponent<Renderer>().isVisible))
        {
            Destroy(this.gameObject);
        }
	}
}
