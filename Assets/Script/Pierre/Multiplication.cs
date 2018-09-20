using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour {

<<<<<<< HEAD
    GameObject player1;
    GameObject playerClone;

    void Start () {      
        player1 = GameObject.Find("player1");
=======
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

>>>>>>> 98bf579c801dff6cf121b991e3c6cf3e4ee13679
    }
	
	// Update is called once per frame
	void Update () {
        //Active le deuxième sprite du GameObject player1
        if ((Input.GetKeyUp("joystick button 0")||Input.GetKeyUp(KeyCode.B)) && GameObject.Find("player1(Clone)")==null)
        {
<<<<<<< HEAD
           
           
            playerClone.GetComponent<Rigidbody2D>().velocity = player1.GetComponent<Rigidbody2D>().velocity;
=======
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
>>>>>>> 98bf579c801dff6cf121b991e3c6cf3e4ee13679
            
        }
        else if((Input.GetKeyUp("joystick button 0")||Input.GetKeyUp(KeyCode.B))&& GameObject.Find("Player(Clone)") != null)
        {
           
<<<<<<< HEAD
            float distance = Vector3.Distance(playerClone.transform.position, player1.transform.position);
            //Debug.Log(distance);
=======
            float distance = Vector3.Distance(playerClone.transform.position, player.transform.position);
>>>>>>> 98bf579c801dff6cf121b991e3c6cf3e4ee13679
            if (distance < 4)
            {
                Destroy(playerClone);
                
               
            }
            



        }

    }
<<<<<<< HEAD
=======

    

    void multiplication ()
    {
        numberOfPlayer += 1;
        pc = player2WithSprite.GetComponent<CapsuleCollider>();
        sr = player2WithSprite.GetComponent<SpriteRenderer>();
        sr.enabled=true;
        pc.enabled = true;
    }
>>>>>>> 98bf579c801dff6cf121b991e3c6cf3e4ee13679
}
