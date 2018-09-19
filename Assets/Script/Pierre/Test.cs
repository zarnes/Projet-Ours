using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float ySpeed = rb.velocity.y;
        float xSpeed = rb.velocity.x;
        if (Input.GetKey(KeyCode.LeftArrow)) rb.velocity = new Vector2(xSpeed+0.3f, 0);
        if (Input.GetKey(KeyCode.RightArrow)) rb.velocity = new Vector2(xSpeed-0.3f,0);
        if (Input.GetKeyUp(KeyCode.LeftArrow) && rb.velocity == new Vector2( 0, 0)) rb.velocity = new Vector2(xSpeed - 0.1f, 0);
    }
}
