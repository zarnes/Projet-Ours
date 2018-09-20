using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private float originY;

    private void Start()
    {
        originY = transform.position.y;
    }

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
            transform.position = new Vector3(transform.position.x, originY, transform.position.z);
        }
	}
}
