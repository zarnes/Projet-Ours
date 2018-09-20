using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	// Quand le joueur appuie sur échap, le jeu se ferme
	void Update () {
			if (Input.GetKey ("escape")) {
				Application.Quit();
			}
		}	
	}

