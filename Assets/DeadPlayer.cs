using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour {

    public GameObject mortSprite;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemi")
        {
            
            //Instantiate(mortSprite);
            SceneManager.LoadScene("level1");
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "DeadZone")
        {

            //Instantiate(mortSprite);
            SceneManager.LoadScene("level1");
            Destroy(gameObject);

        }
    }
}
