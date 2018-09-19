using UnityEngine;

public class BroomBroom : MonoBehaviour
{
    public float Power;
    public float TurnP;
    public Rigidbody rb;

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate()
    { 
            rb.AddForce(transform.forward * Power * Input.GetAxis("Vertical"));
        
            rb.AddTorque(transform.up * TurnP * Input.GetAxis("Horizontal"));
        }
    }
