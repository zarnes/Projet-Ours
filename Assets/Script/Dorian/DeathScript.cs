using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    public GameObject Gameobjects;

    void OnTriggerEnter(Collider other)
    {
        Gameobjects = GameObject.FindGameObjectsWithTag("Respawn");
    }

    
    if (gameObjects.Length == 0)
}
