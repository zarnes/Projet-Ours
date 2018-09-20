using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class DeathScript : MonoBehaviour {
=======
public class DeathScript : MonoBehaviour
{
>>>>>>> ae83ec630e04a39a6e0d6a8f8c0ff13d90a48c86

    public GameObject[] Gameobjects;
    public GameObject MenuDeFin;
    public bool StateOver;

<<<<<<< HEAD
    void OnTriggerEnter(Collider other)
    {
        Collider.GetComponement<GameObject>;
    }

=======
    /// Si l'objet qui touche le collider a le tag player, il se fait détruire
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destroy(other.GetComponement<GameObject>);
    }

    /// Si la scène ne contient pas d'objet avec un tag player, le jeu passe en état de fin
>>>>>>> ae83ec630e04a39a6e0d6a8f8c0ff13d90a48c86
    void FixedUpdate()
    {
        Gameobjects = GameObject.FindGameObjectsWithTag("Player");
        if (Gameobjects.Length == 0)
        {
            StateOver = true;
            MenuDeFin.SetActive(true);
        }
    }
<<<<<<< HEAD
    
}
=======

}
>>>>>>> ae83ec630e04a39a6e0d6a8f8c0ff13d90a48c86
