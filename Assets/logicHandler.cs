using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicHandler : MonoBehaviour {
    //spawn points
    public GameObject[] spawnLocations;
    //static scene objects
    public GameObject[] sceneObjects;

    //dynamic scene objects
    public GameObject[] movingObjects;
    public int minFramesBeforeSpawn = 120;
    public float minRandomBeforeSpawn = 0.95f;
    public bool test = false;

    private float check = 0.0f;
    private int frameCounter = 0;


    // Use this for initialization
    void Start () {
        testStaticRaycasts();
	}
	
	// Update is called once per frame
	void Update () {
        
        frameCounter += 1;
    }

    void testStaticRaycasts() {
        foreach (GameObject sceneObject in sceneObjects)
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.position + Camera.main.transform.position, out hit);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "cube1")
                {
                    //Stub
                    //Change tag comparison to recognize certain object families!
                }
            }
        }
    }

    void testDynamicRaycasts() {
        foreach(GameObject movingObject in movingObjects)
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.position + Camera.main.transform.position, out hit);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "cube1")
                {
                    //Stub
                    //Change tag comparison to recognize certain object families!
                }
            }
        }
    }

    /**
     * This function spawns a specified Object at a specified place.
     * */
    void spawnObject(int objectID, int spawnPointID)
    {
        if (frameCounter > minFramesBeforeSpawn)
        {
            check = Random.value;
            if (check > minRandomBeforeSpawn)
            {
                Instantiate(movingObjects[objectID], spawnLocations[spawnPointID].transform);
            }
            frameCounter = 0;
        }
    }
    /**
     * This function spawns random GameObjects, as specified in the list movingObjects, at random but set locations, as specified in the list spawnLocations.
     * For control over spawned object and location, use the above function.
     **/
    void spawnObject()
    {
        if (frameCounter > minFramesBeforeSpawn)
        {
            check = Random.value;
            if (check > minRandomBeforeSpawn)
            {
                Instantiate(movingObjects[(int) (Random.Range(0.0f, movingObjects.Length + 0.99f))], spawnLocations[(int)(Random.Range(0.0f, spawnLocations.Length + 0.99f))].transform);
            }
            frameCounter = 0;
        }
    }
}
