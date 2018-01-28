using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {

    public Slider health;
    public Text speed;
    public float movementSpeed;
    public float facing;
    bool keyDown;
    public int currentHealth;
    //Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        movementSpeed = 0.0f;
        facing = 0.0f;
        keyDown = false;
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (movementSpeed > 1000)
        {
            movementSpeed = 1000;
        }
        if(movementSpeed < 1000)
        { */
        movementSpeed += Time.deltaTime * 1;
        //}
        movementSpeed = (Mathf.Floor(movementSpeed * 100)) / 100;
        PlayerInput();
        MovePlayer();
        health.value = currentHealth;
        speed.text = ("speed:" + movementSpeed);
        if ((GameObject.Find("Player").transform.position.y < -5) || (currentHealth <= 0))
        {
            SceneManager.LoadScene("Procedural Scene 2 Player");
        }
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
        Vector3 movement = transform.InverseTransformDirection(0.0f, 0.0f, movementSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spike")
        {
            currentHealth -= 20;
            if (movementSpeed > 5)
            {
                movementSpeed -= 5;
            }
            else
            {
                movementSpeed = 0;
            }
            Destroy(other.gameObject);

        }
        if (other.tag == "Boost")
        {
            if (currentHealth < 100)
            {
                currentHealth += 5;
            }
            movementSpeed += 5;
            Destroy(other.gameObject);
        }
    }

}
