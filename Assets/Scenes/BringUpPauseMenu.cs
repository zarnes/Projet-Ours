using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringUpPauseMenu : MonoBehaviour {

    public GameObject MenudePause;
    public bool StatePause = false;

    void Update()
    {
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
    }
}
