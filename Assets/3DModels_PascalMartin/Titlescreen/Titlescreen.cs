using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Titlescreen : MonoBehaviour {

    private Button startButton;
    private Button howtoButton;
    private Button exitButton;
    public Animator playerAnimator;
    public Image blitz;
    private bool startFlash;
    public float blitzSpeed;
    private bool lerpButtonSize;
    private float buttonLerp;
    private Vector2 startSize;
    private Vector2 endSize;

    // Use this for initialization
    void Start () {
        startButton = GetComponentsInChildren<Button>()[0];
        startButton.onClick.AddListener(startPressed);
        //howtoButton = GetComponentsInChildren<Button>()[1];
        //howtoButton.onClick.AddListener(howtoPressed);
        exitButton = GetComponentsInChildren<Button>()[1];
        exitButton.onClick.AddListener(exitPressed);
        startSize = howtoButton.image.rectTransform.sizeDelta;
        endSize = new Vector2(Screen.width - Screen.width / 20, startSize.y);
    }

    // Update is called once per frame
    void Update () {
        if (startFlash)
        {
            blitz.gameObject.transform.localScale += new Vector3(Time.deltaTime * blitzSpeed, Time.deltaTime * blitzSpeed, Time.deltaTime * blitzSpeed);
        }
        if (lerpButtonSize)
        {
            howtoButton.image.rectTransform.sizeDelta = Vector2.Lerp( startSize, endSize, buttonLerp);
            buttonLerp += Time.deltaTime;
        }
    }

    void startPressed()
    {
        playerAnimator.SetBool("takePic", true);
        Invoke("flash", 1f);
        Invoke("startPressed2", 1.2f);
    }

    void howtoPressed()
    {
        buttonLerp = 0;
        lerpButtonSize = true;
    }

    void exitPressed()
    {
        playerAnimator.SetBool("takePic", true);
        Invoke("flash", 1f);
        Invoke("exitPressed2", 1.2f);
    }

    void flash()
    {
        blitz.gameObject.SetActive(true);
        startFlash = true;
    }

    void startPressed2()
    {
        SceneManager.LoadScene("BrandenburgertorScene");
    }

    void exitPressed2()
    {
        Application.Quit();
    }
}
