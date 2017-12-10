﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cameramovement : MonoBehaviour {

    public GameObject fatDude;
    public float zoomOverTime;
    public float offset;
    public GameObject pressAnyKey;
    public Text score;

    // Use this for initialization
    void Start () {
        fatDude.GetComponent<Animator>().SetInteger("randomWalk", 1);
        score.text = "FINAL SCORE: " +GameValues.accMoney.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, fatDude.transform.position.z * zoomOverTime + offset);
        if(fatDude.transform.position.z >= 10)
        {
            pressAnyKey.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }else if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Titlescreen");
        }

	}
}
