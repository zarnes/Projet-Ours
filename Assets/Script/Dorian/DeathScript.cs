﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject[] Gameobjects;
    public GameObject MenuDeFin;
    public bool StateOver;
    private GameObject Target;

    /// Si l'objet qui touche le collider a le tag player, il se fait détruire
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Destroy(other.gameObject);
        }
    }

    /// Si la scène ne contient pas d'objet avec un tag player, le jeu passe en état de fin
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

