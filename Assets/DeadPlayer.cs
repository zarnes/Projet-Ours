using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    public GameObject mortSprite;

    private Animator _animator;
    private static int _alivePlayers = 0;

    private void Start()
    {
        ++_alivePlayers;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Collision(collision.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        Collision(other);
    }

    private void Collision(GameObject go)
    {
        if (go.tag == "Enemi" && go.GetComponent<WhiteCellBehaviour>() == null)
            Die();
        else if (go.tag == "DeadZone")
            Die();
    }

    internal void Die()
    {
        StartCoroutine(CorDie());
    }

    private IEnumerator CorDie()
    {
        --_alivePlayers;
        _animator.SetTrigger("death");

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        // TODO check if last player
        if (_alivePlayers == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
