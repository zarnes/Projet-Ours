using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour {

    public GameObject GOPorte;

    void Start()
    {
        GetComponentInChildren<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            GOPorte.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GOPorte.SetActive(true);
        }
    }

}
