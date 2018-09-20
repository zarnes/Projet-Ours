using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour {

    GameObject player1;
    GameObject playerClone;

    void Start () {      
        player1 = GameObject.Find("player1");
    }
	
	// Update is called once per frame
	void Update () {
        //Active le deuxième sprite du GameObject player1
        if ((Input.GetKeyUp("joystick button 0")||Input.GetKeyUp(KeyCode.B)) && GameObject.Find("player1(Clone)")==null)
        {
           
           
            playerClone.GetComponent<Rigidbody2D>().velocity = player1.GetComponent<Rigidbody2D>().velocity;
            
        }
        else if((Input.GetKeyUp("joystick button 0")||Input.GetKeyUp(KeyCode.B))&& GameObject.Find("player1(Clone)") != null)
        {
           
            float distance = Vector3.Distance(playerClone.transform.position, player1.transform.position);
            //Debug.Log(distance);
            if (distance < 4)
            {
                Destroy(playerClone);
                
               
            }
            



        }

    }
}
