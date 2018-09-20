using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
	
	// Update is called once per frame
	void Update ()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
		if (moveX != 0 || moveY != 0)
        {
            moveX *= Time.deltaTime * Speed;
            moveY *= Time.deltaTime * Speed;

            transform.Translate(new Vector3(moveX, 0, moveY));
        }
	}
}
