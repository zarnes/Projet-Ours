using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    public GameObject mortSprite;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemi")
            Die();
        else if (collision.gameObject.tag == "DeadZone")
            Die();
    }

    internal void Die()
    {
        StartCoroutine(CorDie());
    }

    private IEnumerator CorDie()
    {
        _animator.SetTrigger("death");

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        // TODO check if last player
        //SceneManager.LoadScene("level1");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "DeadZone")
        {

            //Instantiate(mortSprite);
            SceneManager.LoadScene("level1");
            Destroy(gameObject);

        }
    }
}
