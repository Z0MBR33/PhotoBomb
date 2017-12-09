using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicHandler : MonoBehaviour
{
    //spawn points
    public GameObject[] spawnLocations;
    //static scene objects
    public GameObject[] sceneObjects;

    //dynamic scene objects
    public GameObject[] movingObjectsList;
    private List<GameObject> movingObjects = new List<GameObject>();
    public int minFramesBeforeSpawn = 120;
    public float minRandomBeforeSpawn = 0.95f;
    public bool test = false;

    private float check = 0.0f;
    private int frameCounter = 0;

    //used for camera logic
    private int takenPhotos = 0;
    private int[] photos = new int[] {0, 0, 0}; //this array stores money values for taken photos


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (frameCounter > minFramesBeforeSpawn && movingObjectsList.Length > 0 && spawnLocations.Length > 0)
        {
            spawnObject();
        }
        frameCounter += 1;
    }

    /**
     * ONLY do this for static objects that can be interacted with or that only overlay from a certain view.
     * Point deduction is not as tragic with static objects as they can't be avoided.
     **/
    public int testStaticRaycasts()
    {
        int money = 0;
        foreach (GameObject sceneObject in sceneObjects)
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.position + Camera.main.transform.position, out hit);
            if (hit.collider != null)
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "verygood": money -= 10; break;
                    case "good": money -= 2; break;
                    case "bad": money += 5; break;
                    case "verybad": money += 15; break;
                }
                if (money < 0)
                    money = 0;
            }
        }
        return money;
    }

    public int testDynamicRaycasts()
    {
        int money = 0;
        foreach (GameObject movingObject in movingObjects)
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.position + Camera.main.transform.position, out hit);
            if (hit.collider != null)
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "verygood": money -= 50; break;
                    case "good": money -= 10; break;
                    case "bad": money += 10; break;
                    case "verybad": money += 50; break;
                }
                if (money < 0)
                    money = 0;
            }
        }
        return money;
    }

    /**
     * Trigger this function to get extra points from amazing attractions, like terrorists, explosions etc.
     * */
    public int getAmazingAttractions()
    {
        int money = 0;
        GameObject[] amazingObjects = GameObject.FindGameObjectsWithTag("amazing");
        if (amazingObjects.Length > 0)
        {
            foreach (GameObject amazingObject in amazingObjects)
            {
                if (amazingObject.GetComponent<Renderer>().isVisible)
                {
                    money += 50;
                }
            }
        }
        return money;
    }

    /**
     * This function spawns a specified Object at a specified place.
     * */
    public void spawnObject(int objectID, int spawnPointID)
    {
        if (frameCounter > minFramesBeforeSpawn)
        {
            check = Random.value;
            if (check > minRandomBeforeSpawn)
            {
                movingObjects.Add(Instantiate(movingObjectsList[objectID], spawnLocations[spawnPointID].transform.position, Quaternion.identity));
            }
            frameCounter = 0;
        }
    }
    /**
     * This function spawns random GameObjects, as specified in the list movingObjects, at random but set locations, as specified in the list spawnLocations.
     * For control over spawned object and location, use the above function.
     **/
    public void spawnObject()
    {
        check = Random.value;
        if (check > minRandomBeforeSpawn)
        {
            movingObjects.Add(Instantiate(movingObjectsList[(int)(Random.Range(0.0f, movingObjectsList.Length - 0.01f))], spawnLocations[(int)(Random.Range(0.0f, spawnLocations.Length - 0.01f))].transform.position, Quaternion.identity));
        }
        frameCounter = 0;
    }
}
