using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Rigidbody2D rb;
    float maxSpeed=6;
    // Use this for initialization

    void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float ySpeed = rb.velocity.y;
        float xSpeed = rb.velocity.x;

        if (Input.GetKey(KeyCode.LeftArrow)&&xSpeed>-maxSpeed) rb.velocity = new Vector2(xSpeed-0.4f, ySpeed);
        if (Input.GetKey(KeyCode.RightArrow)&&xSpeed<maxSpeed) rb.velocity = new Vector2(xSpeed+0.4f,ySpeed);

        if (Input.GetKey(KeyCode.DownArrow) && ySpeed > -maxSpeed) rb.velocity = new Vector2(xSpeed, ySpeed - 0.4f);
        if (Input.GetKey(KeyCode.UpArrow) && ySpeed > -maxSpeed) rb.velocity = new Vector2(xSpeed, ySpeed + 0.4f);
    }
}
