using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Titlescreen : MonoBehaviour {

    private Button startButton;
    private Button howtoButton;
    public Text howtoText;
    private Button exitButton;
    public Animator playerAnimator;
    public Image blitz;
    private bool startFlash;
    public float blitzSpeed;

    // Use this for initialization
    void Start () {
        startButton = GetComponentsInChildren<Button>()[0];
        startButton.onClick.AddListener(StartPressed);
        howtoButton = GetComponentsInChildren<Button>()[1];
        howtoButton.onClick.AddListener(HowtoPressed);
        exitButton = GetComponentsInChildren<Button>()[2];
        exitButton.onClick.AddListener(ExitPressed);
    }

    // Update is called once per frame
    void Update () {
        if (startFlash)
        {
            blitz.gameObject.transform.localScale += new Vector3(Time.deltaTime * blitzSpeed, Time.deltaTime * blitzSpeed, Time.deltaTime * blitzSpeed);
        }
    }

    void StartPressed()
    {
        playerAnimator.SetBool("takePic", true);
        Invoke("Flash", 1f);
        Invoke("StartPressed2", 1.2f);
    }

    void HowtoPressed()
    {
        if (howtoText.GetComponent<Animator>().GetBool("isActivated")) {
            howtoText.GetComponent<Animator>().SetBool("isActivated", false);
        }
        else
        {
            howtoText.GetComponent<Animator>().SetBool("isActivated", true);
        }
    }

    void ExitPressed()
    {
        playerAnimator.SetBool("takePic", true);
        Invoke("Flash", 1f);
        Invoke("ExitPressed2", 1.2f);
    }

    void Flash()
    {
        blitz.gameObject.SetActive(true);
        startFlash = true;
    }

    void StartPressed2()
    {
        SceneManager.LoadScene(1);
    }

    void ExitPressed2()
    {
        Application.Quit();
    }
}
