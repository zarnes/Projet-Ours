using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplication : MonoBehaviour {
    GameObject playerClone;
    GameObject player;
    GameObject[] playerTab;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("player1");
	}
	
	// Update is called once per frame
	void Update () {



        playerTab = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(playerTab.Length);
        if ((Input.GetKeyUp(KeyCode.M) || Input.GetKeyUp("joystick button 1")))

            if (playerTab.Length <= 2)
            {
                playerClone = Instantiate(player, player.transform.position, player.transform.rotation);
                playerClone.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody2D>().velocity;
                Debug.Log("Multiplication");
            }
            
        }
 }

