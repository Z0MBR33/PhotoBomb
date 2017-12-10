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
    public GameObject myRagDoll;
    public GameObject myAnimationRig;
    private Rigidbody myRigid;
    private CapsuleCollider myCapCol;

    private bool start = false;
    private float myRandomScale;
    


    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();
        randomScale();
        randomWalkStyle();
        myCapCol = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
	}

    private void randomScale()
    {
        myRandomScale = UnityEngine.Random.Range(0.15f, 0.25f);
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

    public void SwitchMode()
    {
        myRigid.isKinematic = true;
        myCapCol.enabled = false;
        myAnim.enabled = false;
        myRagDoll.SetActive(true);
        myAnimationRig.SetActive(false);
        start = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<moveMe>() != null || other.gameObject.GetComponentInParent<moveMe>() != null)
        {

                SwitchMode();

        }
            /*
            if(other.gameObject.GetComponent<moveMe>() != null || other.gameObject.GetComponentInParent<moveMe>() != null)
            {
                if(other.gameObject.GetComponent<moveMe>().myRagDoll == false)
                {
                    other.gameObject.GetComponent<moveMe>().SwitchMode();
                }
                SwitchMode();
            }
            */
        }
}
