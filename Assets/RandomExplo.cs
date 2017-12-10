using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplo : MonoBehaviour {
    public bool imATerrorist;
    public float myRandomTimer;

    public GameObject myExplosion;
    public moveMe myScript;
    void Start()
    {
        myRandomTimer = UnityEngine.Random.Range(2,15);
        StartCoroutine(Example());
        myScript = GetComponent<moveMe>();
    }

    IEnumerator Example()
    {
        //print(Time.time);
        yield return new WaitForSeconds(myRandomTimer);
        myScript.SwitchMode();
        myExplosion.SetActive(true);

        //print(Time.time);
    }

    // Update is called once per frame
    void Update () {
		
	}


}
