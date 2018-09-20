using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    float speed = 0.2f;
    //Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        //rb = this.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical_translation = Input.GetAxis("Vertical") * speed;
        float horizontal_translation = Input.GetAxis("Horizontal") * speed;
        transform.Translate(horizontal_translation, 0, 0);
        transform.Translate(0, vertical_translation, 0);
    }
}
