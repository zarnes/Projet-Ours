using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplication : MonoBehaviour {
    GameObject playerClone;
    GameObject player;
    GameObject[] playerTab;
    GameObject playerClonePosition;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("player1");
        playerClonePosition = GameObject.Find("playerClonePosition");
	}
	
	// Update is called once per frame
	void Update () {



        playerTab = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(playerTab.Length);
        if ((Input.GetKeyUp(KeyCode.M) || Input.GetKeyUp("joystick button 1")))

            if (playerTab.Length <= 2)
            {
                playerClone = Instantiate(player, playerClonePosition.transform.position, playerClonePosition.transform.rotation);
                playerClone.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
                Debug.Log("Multiplication");
            }
            
        }
 }

