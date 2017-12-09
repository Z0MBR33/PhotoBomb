using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WalkStyles
{
    crawl,walk1,walk2,walk3,walk4,walk5,walk6,walk7,walk8,walk9
}



public class moveMe : MonoBehaviour {

    public int animNum;
    public float speed;
    private Animator myAnim;
    private bool start = false;
    private float myRandomScale;


    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();
        randomScale();
        randomWalkStyle();
	}

    private void randomScale()
    {
        myRandomScale = UnityEngine.Random.Range(0.15f, 0.35f);
        gameObject.transform.localScale =new Vector3(myRandomScale,myRandomScale,myRandomScale);
    }

    private void randomWalkStyle()
    {
        animNum = UnityEngine.Random.Range(0, 11);
        myAnim.SetInteger("randomWalk", animNum);
        start = true;
    }

    // Update is called once per frame
    void Update () {
        if (start)
        {
            this.transform.Translate(Vector3.forward * 0.008f);//Time.deltaTime);
        }
        
	}
}
