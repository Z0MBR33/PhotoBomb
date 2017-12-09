using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papparazzi : MonoBehaviour {

    Rigidbody body;
    Quaternion originalRotation;
    Vector3 originalPosition;
    private bool canMove;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    float moveX = 0F;
    float moveY = 0F;
    public float minimumX = -20F;
    public float maximumX = 20F;
    public float minimumY = -10F;
    public float maximumY = 10F;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
        if (body)
            body.freezeRotation = true;
        originalRotation = transform.localRotation;
        originalPosition = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            moveX += Input.GetAxis("Mouse X") * sensitivityX;
            moveY += Input.GetAxis("Mouse Y") * sensitivityY;
            moveX = Mathf.Clamp(moveX + transform.position.x, minimumX, maximumX) - transform.position.x;
            moveY = Mathf.Clamp(moveY + transform.position.y, minimumY, maximumY) - transform.position.y;
            transform.position = new Vector3(moveX, moveY, originalPosition.z);
        }
        if (Input.GetMouseButtonDown(0))
        {
            canMove = false;
            Snap();
        }

    }

    private void Snap()
    {
        //TODO: Snapshot
        canMove = true;
    }
}
