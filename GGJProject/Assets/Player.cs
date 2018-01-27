using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float facing;
    bool keyDown;
    // Use this for initialization
    void Start()
    {
        movementSpeed = 0.0f;
        facing = 0.0f;
        keyDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed += Time.deltaTime;
        PlayerInput();
        MovePlayer();
    }
    void PlayerInput()
    {
        if (Input.GetKeyDown("a"))
        {
            RotatePlayer(90.0f);
        }
        if (Input.GetKeyDown("d"))
        {
            RotatePlayer(-90.0f);
        }
    }
    void RotatePlayer(float rotateAmount)
    { 
        transform.Rotate(Vector3.up, rotateAmount);

    }
    void MovePlayer()
    {
        Vector3 movement = transform.InverseTransformDirection(0.0f,0.0f,movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}