using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringUpPauseMenu : MonoBehaviour {

    public GameObject MenudePause;
    public bool StatePause = false;

    void Update()
    {
        ///Si le Joueur appuie sur échap, le jeu passe en état de pause et affiche le menu pause, si il appuie sur échap à nouveau, le menu pause disparait et le jeu reprend
        if (Input.GetKey("escape"))
        {
            if (StatePause == false)
            {
                StatePause = true;
                Time.timeScale = 0;
                MenudePause.SetActive(true);
            }
            if (StatePause == true)
            {
                StatePause = false;
                Time.timeScale = 1;
                MenudePause.SetActive(true);
            }
        }
        ///Si le Joueur appuie sur le boutton Start, le jeu passe en état de pause et affiche le menu pause, si il appuie sur le boutton Start à nouveau, le menu pause disparait et le jeu reprend
        if (Input.GetButton("Start"))
        {
            if (StatePause == false)
            {
                StatePause = true;
                Time.timeScale = 0;
                MenudePause.SetActive(true);
            }
            if (StatePause == true)
            {
                StatePause = false;
                Time.timeScale = 1;
                MenudePause.SetActive(true);
            }
        }
    }
}
