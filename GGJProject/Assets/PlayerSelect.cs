using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {
    bool twoPlayer;
	// Use this for initialization
	void Start ()
    {
        twoPlayer = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerInput();
	}
    public void OnMouseClick()
    {
        if (twoPlayer != true)
        {
            SceneManager.LoadScene("Procedural Scene");
        }
        else
        {
            SceneManager.LoadScene("Procedural Scene 2 Player");
        }
    }
    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Text text = GameObject.Find("Player2Text").gameObject.GetComponent<Text>();
            text.text = "Player 2 is Ready";
            twoPlayer = true;
        }
    }
}
