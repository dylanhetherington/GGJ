using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        findPlayerPosition();
    }
    void findPlayerPosition()
    {
        Transform player = GameObject.Find("Player").transform;
        transform.position = new Vector3(player.position.x, player.position.y + 3.6f, player.position.z - 4.0f);
    }
    public void AdjustCameraRotation(Transform player)
    {

    }
}
