using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Papparazzi : MonoBehaviour
{

    Rigidbody body;
    Quaternion originalRotation;
    Vector3 originalPosition;
    bool notPressed;
    private int shots;
    public int maxshots = 3;
    private bool canMove = false;
    public float sensitivityX = .7F;
    public float sensitivityY = .7F;
    float moveX = 0F;
    float moveY = 0F;
    public float minimumX = -10F;
    public float maximumX = 10F;
    public float minimumY = 0;
    public float maximumY = 10F;
    public float movementSpeed = 5F;
    int[] monies;
    private static int money;
    Rect rekt;
    Texture2D[] snap;
    public logicHandler handler;
    public RawImage zeitung;
    private RawImage zeitungsbild;

    // Use this for initialization
    void Start()
    {
        zeitungsbild = zeitung.GetComponentsInChildren<RawImage>()[1];
        rekt = Rect.MinMaxRect(100, 100, Screen.width -100, Screen.height -100);
        body = GetComponent<Rigidbody>();
        if (body)
            body.freezeRotation = true;
        originalPosition = transform.position;
        shots = maxshots;
        snap = new Texture2D[maxshots];
        monies = new int[maxshots];
        notPressed = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            moveX = Input.GetAxis("Mouse X") * sensitivityX;
            moveY = Input.GetAxis("Mouse Y") * sensitivityY;
            moveX = Mathf.Clamp(moveX + transform.position.x, originalPosition.x + minimumX, originalPosition.x + maximumX) - transform.position.x;
            moveY = Mathf.Clamp(moveY + transform.position.y, originalPosition.y + minimumY, originalPosition.y + maximumY) - transform.position.y;
            transform.Translate(moveX, moveY, 0F);
            if (Input.GetMouseButtonDown(0))
            {
                monies[maxshots-shots] = handler.testStaticRaycasts() + handler.testDynamicRaycasts() + handler.getAmazingAttractions();
                Debug.Log("$$$: " + monies[maxshots - shots]);
                canMove = false;
                Camera.onPostRender += Snap;
            }
        }
        if (!notPressed)
            if(Input.anyKeyDown)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    void OnGUI()
    {
        if (shots == 0)
        {
            Cursor.visible = true;
            canMove = false;
            if(notPressed)
            if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 5, Screen.height / 5), snap[0]))
            {
                GameValues.accMoney += monies[0];
                Debug.Log("Total$: " + GameValues.accMoney);
                    notPressed = false;
                startZeitung(0);
            }

            if (notPressed)
                if (maxshots > 1)
                if (GUI.Button(new Rect(2 * Screen.width / 4, Screen.height / 4, Screen.width / 5, Screen.height / 5), snap[1]))
                {
                    GameValues.accMoney += monies[1];
                    Debug.Log("Total$: " + GameValues.accMoney);
                        notPressed = false;
                        startZeitung(1);
                    }
            if (notPressed)
                if (maxshots > 2) 
                if (GUI.Button(new Rect(3 * Screen.width / 4, Screen.height / 4, Screen.width / 5, Screen.height / 5), snap[2]))
                {
                    GameValues.accMoney += monies[2];
                    Debug.Log("Total$: " + GameValues.accMoney);
                        notPressed = false;
                        startZeitung(2);
                }

            if (notPressed)
                if (maxshots > 3)
                if (GUI.Button(new Rect(Screen.width / 4, 3 * Screen.height / 4, Screen.width / 5, Screen.height / 5), snap[3]))
                {
                    GameValues.accMoney += monies[3];
                    Debug.Log("Total$: " + GameValues.accMoney);
                        notPressed = false;
                        startZeitung(3);
                }

            if (notPressed)
                if (maxshots > 4)
                if (GUI.Button(new Rect(2 * Screen.width / 4, 3 * Screen.height / 4, Screen.width / 5, Screen.height / 5), snap[4]))
                {
                    GameValues.accMoney += monies[4];
                    Debug.Log("Total$: " + GameValues.accMoney);
                        notPressed = false;
                        startZeitung(4);
                }

            if (notPressed)
                if (maxshots > 5)
                if (GUI.Button(new Rect(3 * Screen.width / 4, 3 * Screen.height / 4, Screen.width / 5, Screen.height / 5), snap[5]))
                {
                    GameValues.accMoney += monies[5];
                        Debug.Log("Total$: " + GameValues.accMoney);
                        notPressed = false;
                        startZeitung(5);
                }

            //TODO: LevelOutro->ChangeLevel
        }
    }

    void startZeitung(int whichImage)
    {
        zeitung.gameObject.SetActive(true);
        zeitung.GetComponent<Animator>().Play("zeitung");
        zeitungsbild.texture = snap[whichImage];
    }

    void OnPostRender()
    {
        if (shots > 0) canMove = true;
    }

    private void Snap(Camera cam)
    {
        Camera.onPostRender -= Snap;
        if (shots > 0)
        {
            snap[maxshots - shots] = new Texture2D(Screen.width/2, Screen.height/2);
            snap[maxshots - shots].ReadPixels(rekt, 0, 0);
            snap[maxshots - shots].Apply();
            shots--;
            canMove = true;
        }

    }
}