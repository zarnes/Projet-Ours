using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float Acceleration;
    public float MaxVitesse;
    public float Friction;

    private Rigidbody Rb;

    // Use this for initialization
    void Start () {
        Rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 inputValue = new Vector3(-Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(inputValue != Vector3.zero)
        {
            Rb.velocity += inputValue.normalized * Acceleration * Time.deltaTime;
            if(Rb.velocity.magnitude > MaxVitesse)
            {
                Rb.velocity = Rb.velocity.normalized * MaxVitesse;
            }
        }
        else if (Rb.velocity != Vector3.zero)
        {
            if (Rb.velocity.magnitude > Friction * Time.deltaTime)
                Rb.velocity -= Rb.velocity.normalized * Friction * Time.deltaTime;
            else
            {
                Rb.velocity = Vector3.zero;
            }
        }

	}
}
