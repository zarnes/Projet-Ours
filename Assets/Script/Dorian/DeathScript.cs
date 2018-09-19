using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    public GameObject[] Gameobjects;
    public GameObject MenuDeFin;
    public bool StateOver;

    void OnTriggerEnter(Collider other)
    {
        Collider.GetComponement<GameObject>
    }

    void FixedUpdate()
    {
        Gameobjects = GameObject.FindGameObjectsWithTag("Player");
        if (Gameobjects.Length == 0)
        {
            StateOver = true;
            MenuDeFin.SetActive(true);
        }
    }
    
}
