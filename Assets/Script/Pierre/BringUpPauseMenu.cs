using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringUpPauseMenu : MonoBehaviour {

    public GameObject MenuPause;
    public bool StatePause = false;
  
   
    void Update()
    {
        ///Si le Joueur appuie sur échap, le jeu passe en état de pause et affiche le menu pause, si il appuie sur échap à nouveau, le menu pause disparait et le jeu reprend
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StatePause == false)
            {
                MenuPause.SetActive(true);
                StatePause = true;
                Time.timeScale = 0;
                
                //canvas.enabled=true;
            }
            else if (StatePause == true)
            {
                StatePause = false;
                Time.timeScale = 1;
                MenuPause.SetActive(false);
            }
        }
        ///Si le Joueur appuie sur le boutton Start, le jeu passe en état de pause et affiche le menu pause, si il appuie sur le boutton Start à nouveau, le menu pause disparait et le jeu reprend
        if (Input.GetButtonDown("Start"))
        {
            if (StatePause == false)
            {
                StatePause = true;
                Time.timeScale = 0;
                MenuPause.SetActive(true);
            }
            else if (StatePause == true)
            {
                StatePause = false;
                Time.timeScale = 1;
                MenuPause.SetActive(false);
            }
        }
    }
}
