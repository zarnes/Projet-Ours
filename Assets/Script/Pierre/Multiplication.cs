using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour {

    int numberOfPlayer;
    GameObject player2WithSprite;
    CapsuleCollider pc;
    SpriteRenderer sr;
    GameObject player;
    GameObject playerClone;

    void Start () {
        numberOfPlayer = 1;
        player2WithSprite = GameObject.Find("player1_cellule2");
        player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
        //Active le deuxième sprite du GameObject player1
        if ((Input.GetKeyUp(KeyCode.M)||Input.GetKeyUp("joystick button 1")) && numberOfPlayer<2) 
        {
            multiplication();
            numberOfPlayer = 2;
        }

        if ((Input.GetKeyUp("joystick button 0")||Input.GetKeyUp(KeyCode.B)) && GameObject.Find("Player(Clone)")==null&&numberOfPlayer==2)
        {
            pc = player2WithSprite.GetComponent<CapsuleCollider>();
            pc.enabled = false;
            sr = player2WithSprite.GetComponent<SpriteRenderer>();
            sr.enabled = false;
            playerClone = Instantiate(player, player2WithSprite.transform.position, player2WithSprite.transform.rotation);
            playerClone.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
            
        }
        else if((Input.GetKeyUp("joystick button 0")||Input.GetKeyUp(KeyCode.B))&& GameObject.Find("Player(Clone)") != null)
        {
           
            float distance = Vector3.Distance(playerClone.transform.position, player.transform.position);
            if (distance < 4)
            {
                Destroy(playerClone);
                multiplication();
                numberOfPlayer = 2;
            }
            else numberOfPlayer = 1;



        }

    }

    

    void multiplication ()
    {
        numberOfPlayer += 1;
        pc = player2WithSprite.GetComponent<CapsuleCollider>();
        sr = player2WithSprite.GetComponent<SpriteRenderer>();
        sr.enabled=true;
        pc.enabled = true;
    }
}
