using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    bool verticalTranslation_active;
    bool horizontalTranslation_active;
    float speed = 0.2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical_translation = Input.GetAxis("Vertical") * speed;
        float horizontal_translation = Input.GetAxis("Horizontal") * speed;
       /* transform.Translate(horizontal_translation, 0, 0);
        transform.Translate(0, vertical_translation, 0);*/
    }
}
