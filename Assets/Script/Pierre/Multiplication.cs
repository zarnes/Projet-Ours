using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour {
    int numberOfCells;
    GameObject cellule;
    SpriteRenderer spriteRenderer;
    PolygonCollider2D celluleCollider;
    // Use this for initialization
    void Start () {
        numberOfCells = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.M) && numberOfCells<4) 
        {
            Debug.Log("MULTIPLICATION");
            multiplication();
        }
	}

    

    void multiplication ()
    {
        numberOfCells += 1;
        cellule = GameObject.Find("cellule" + numberOfCells);
        if (cellule == null) Debug.Log("Objet non trouvé");
        spriteRenderer = cellule.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        celluleCollider = cellule.GetComponent<PolygonCollider2D>();
        celluleCollider.enabled = true;

    }
}
