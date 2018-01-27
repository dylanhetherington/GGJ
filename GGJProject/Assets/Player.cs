using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float facing;
    bool keyDown;
    public int health;
    //Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        movementSpeed = 0.0f;
        facing = 0.0f;
        keyDown = false;
        health = 100;
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
        if (Input.GetKey("a"))
        {
            RotatePlayer(-15.0f);
        }
        if (Input.GetKey("d"))
        {
            RotatePlayer(15.0f);
        }
    }
    void RotatePlayer(float rotateAmount)
    { 
        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime);

    }
    void MovePlayer()
    {
        Vector3 movement = transform.InverseTransformDirection(0.0f,0.0f,movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spike")
        {
            health -= 25;
            movementSpeed -= 20;
            Destroy(other.gameObject);
            
        }
        if (other.tag == "Boost")
        {
            movementSpeed += 20;
            Destroy(other.gameObject);
        }
    }

}