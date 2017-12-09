using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour {

    public GameObject movingObject;
    public int minFramesBeforeSpawn = 0;
    public float minRandomBeforeSpawn = 0.95f;
    public bool test = false;

    private float check = 0.0f;
    private int frameCounter = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (frameCounter > minFramesBeforeSpawn)
        {
            check = Random.value;
            Debug.Log(check);
            if (check > minRandomBeforeSpawn)
            {
                Instantiate(movingObject, this.transform);
                Debug.Log("spawned object");
            }
            frameCounter = 0;
        }
        frameCounter += 1;
    }
}
