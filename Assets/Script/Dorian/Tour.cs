using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Tour : MonoBehaviour {

	public GameObject Timertext;

	void OnTriggerEnter(Collider other)
	{
		Timertext.GetComponent<Timer>().Fin = true;
        Timertext.GetComponent<Timer>().Fin = false;
    }
}