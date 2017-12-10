using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papparazzi : MonoBehaviour
{

    Rigidbody body;
    Quaternion originalRotation;
    Vector3 originalPosition;
    private int shots;
    public int maxshots = 3;
    private bool canMove = false;
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    float moveX = 0F;
    float moveY = 0F;
    public float minimumX = -10F;
    public float maximumX = 10F;
    public float minimumY = -5F;
    public float maximumY = 5F;
    public float movementSpeed = 5F;
    int[] monies = new int[] { 0, 0, 0 };
    private static int money;
    Rect rekt;
    Texture2D[] snap = new Texture2D[3];
    public logicHandler handler;

    // Use this for initialization
    void Start()
    {
        rekt = new Rect(Screen.width / 2 - 360, Screen.height / 2 - 240, 720, 480);
        body = GetComponent<Rigidbody>();
        if (body)
            body.freezeRotation = true;
        originalPosition = transform.position;
        shots = maxshots;
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


    }

    void OnGUI()
    {
        if (shots == 0)
        {
            canMove = false;

            if (GUI.Button(new Rect(100, 100, 288, 192), (Texture)snap[0]))
            {

            }
            if (GUI.Button(new Rect(400, 100, 288, 192), (Texture)snap[1]))
            {

            }
            if (GUI.Button(new Rect(700, 100, 288, 192), (Texture)snap[2]))
            {

            }

            //TODO: LevelOutro->ChangeLevel
        }
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
            //TODO: Snapshot
            snap[maxshots - shots] = new Texture2D(720, 480);
            snap[maxshots - shots].ReadPixels(rekt, 0, 0);
            snap[maxshots - shots].Apply();
            shots--;
            //snap[maxshots - shots] = Sprite.Create(tex, rekt, new Vector2(360, 240), 100f, 0, SpriteMeshType.FullRect, Vector4.zero);
            canMove = true;
        }

    }
}