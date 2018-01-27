using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 displacement;
    Vector3 velocity;
    Vector3 acceleration;
    Vector3 resultantForce;
    float sideForce, upForce, forwardForce;
    int health;
    float mass;
    bool onGround;

    // Use this for initialization
	void Start ()
    {
        onGround = true;
        mass = 10;
        health = 3;
        displacement = new Vector3(0.0f, 0.0f, 0.0f);
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
        resultantForce = new Vector3(0.0f, 0.0f, 0.0f);
        sideForce = 0;
        upForce = 0;
        forwardForce = 10;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        KeyInput();
        checkOnGround();
	}
    void VelocityCalculation()
    {
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        velocity.z += acceleration.z * Time.deltaTime;
    }
    void AddForce()
    {
        resultantForce.x = sideForce;
        resultantForce.y = upForce;
        resultantForce.z = forwardForce;
        if (onGround == false)
        {
            upForce = -9.81f;
            checkOnGround();
        }
    }
    void checkOnGround()
    {
        if (transform.position.y < 0)
        {
            transform.position.Set(transform.position.x, 0.0f, transform.position.z);
        }
        if (transform.position.y < 0)
        {
            onGround = true;
            upForce = 0.0f;
            velocity.y = 0.0f;
        }
        if (transform.position.y > 5)
        {
            onGround = false;
        }
    }
    void AccelerationCalculation()
    {
        acceleration.x = resultantForce.x / mass;
        acceleration.y = resultantForce.y / mass;
        acceleration.z = resultantForce.z / mass;
    }

    void Move()
    {
        AddForce();
        AccelerationCalculation();
        VelocityCalculation();
        displacement.x += velocity.x * Time.deltaTime + 0.5f * acceleration.x * Time.deltaTime * Time.deltaTime;
        displacement.y += velocity.y * Time.deltaTime + 0.5f * acceleration.y * Time.deltaTime * Time.deltaTime;
        displacement.z += velocity.z * Time.deltaTime + 0.5f * acceleration.z * Time.deltaTime * Time.deltaTime;
        transform.position = new Vector3(displacement.x, displacement.y, displacement.z);
        //transform.Rotate(new Vector3(0.0f, displacement.x, 0.0f));
        if (sideForce > 0)
        {
            sideForce -= Time.deltaTime;
            if (sideForce < 0)
            {
                sideForce = 0;
            }
        }
        if (sideForce < 0)
        {
            sideForce += Time.deltaTime;
            if (sideForce > 0)
            {
                sideForce = 0;
            }
        }
        if (upForce > 0)
        {
            upForce -= Time.deltaTime;
            if (upForce < 0)
            {
                upForce = 0;
            }
        }
        if (upForce < 0)
        {
            upForce += Time.deltaTime;
            if (upForce > 0)
            {
                upForce = 0;
            }
        }
        if (forwardForce > 0)
        {
            forwardForce -= Time.deltaTime;
            if (forwardForce < 0)
            {
                forwardForce = 0;
            }
        }
        if (forwardForce < 0)
        {
            forwardForce += Time.deltaTime;
            if (forwardForce > 0)
            {
                forwardForce = 0;
            }
        }
    }

    void KeyInput()
    {
        if (Input.GetKeyDown("a"))
        {
            sideForce = 0;
            sideForce += -10;
            velocity.x = -0.2f;
        }
        if (Input.GetKeyDown("d"))
        {
            sideForce = 0;
            sideForce += 10;
            velocity.x = 0.2f;
        }
        if (Input.GetKeyDown("q"))
        {
            upForce += 10;
        }

    }
}