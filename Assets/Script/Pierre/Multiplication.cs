using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour {

    int numberOfPlayer;
    GameObject player2WithSprite;
    PolygonCollider2D pc;
    SpriteRenderer sr;
    GameObject player1;
    GameObject playerClone;

    void Start () {
        numberOfPlayer = 1;
        player2WithSprite = GameObject.Find("player1_cellule2");
        player1 = GameObject.Find("player1");

    }
	
	// Update is called once per frame
	void Update () {
        //Active le deuxième sprite du GameObject player1
        if (Input.GetKeyUp(KeyCode.M) && numberOfPlayer<2) 
        {
            multiplication();
            numberOfPlayer = 2;
        }

        if (Input.GetKeyUp(KeyCode.B)&&GameObject.Find("player1(Clone)")==null&&numberOfPlayer==2)
        {
            pc = player2WithSprite.GetComponent<PolygonCollider2D>();
            pc.enabled = false;
            sr = player2WithSprite.GetComponent<SpriteRenderer>();
            sr.enabled = false;
            playerClone = Instantiate(player1, player2WithSprite.transform.position, player2WithSprite.transform.rotation);
        }
        else if(Input.GetKeyUp(KeyCode.B) && GameObject.Find("player1(Clone)") != null)
        {
           
            float distance = Vector3.Distance(playerClone.transform.position, player1.transform.position);
            Debug.Log(distance);
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
        pc = player2WithSprite.GetComponent<PolygonCollider2D>();
        sr = player2WithSprite.GetComponent<SpriteRenderer>();
        sr.enabled=true;
        pc.enabled = true;
    }
}
