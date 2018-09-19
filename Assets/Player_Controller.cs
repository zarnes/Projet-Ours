using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float Acceleration;
    public float MaxVitesse;
    public float Friction;

    private Rigidbody2D Rb;

    // Use this for initialization
    void Start () {
        Rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 inputValue = new Vector2(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(inputValue != Vector2.zero)
        {
            Rb.velocity += inputValue.normalized * Acceleration * Time.deltaTime;
            if(Rb.velocity.magnitude > MaxVitesse)
            {
                Rb.velocity = Rb.velocity.normalized * MaxVitesse;
            }
        }
        else if (Rb.velocity != Vector2.zero)
        {
            if (Rb.velocity.magnitude > Friction * Time.deltaTime)
                Rb.velocity -= Rb.velocity.normalized * Friction * Time.deltaTime;
            else
            {
                Rb.velocity = Vector2.zero;
            }
        }

	}
}
