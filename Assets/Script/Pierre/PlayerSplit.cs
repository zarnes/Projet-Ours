using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplit : MonoBehaviour {
    GameObject player2;
	
	void Start () {
		player2 = GameObject.Find("player2_cellule");
	}


    void Update()
    {

        if (Input.GetKey(KeyCode.B))
        {

        }
    }
        
}
