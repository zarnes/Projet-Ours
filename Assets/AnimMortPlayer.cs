using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMortPlayer : MonoBehaviour {
    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
