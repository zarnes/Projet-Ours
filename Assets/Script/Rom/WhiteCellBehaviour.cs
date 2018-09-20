using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WhiteCellBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _nextCalculation;
    private Animator _animator;

    public float AggroDistance;
    public float AbandonDistance;

    public Transform Player;
    public float RecalculationTime;

    public bool IsFollowingPlayer;
    private bool _isEating = false;

	// Use this for initialization
	void Start ()
    {
        FindNearestPlayer();
        _agent = GetComponent<NavMeshAgent>();
        _nextCalculation = Time.time;
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_isEating)
            return;

        if (Time.time > _nextCalculation)
            FindNearestPlayer();

        if (Player == null)
        {
            Debug.LogWarning("Can't find any player to chase");
            return;
        }

        float distance = Vector3.Distance(Player.position, transform.position);
        Vector3 direction = Player.position - transform.position;
        RaycastHit hit;

        // If close enough, check raycast then follow player
        if (distance < AggroDistance && !IsFollowingPlayer)
        {
            Debug.DrawRay(transform.position, direction, Color.red);
            if (Physics.Raycast(transform.position, direction, out hit, distance))
            {
                if (hit.transform.tag == "Player")
                {
                    IsFollowingPlayer = true;
                    _animator.SetTrigger("move");
                }
            }
            
        }
        // If too far, abandon player
        else if (distance > AbandonDistance && IsFollowingPlayer)
        {
            Stop();
        }
        
        if (IsFollowingPlayer && Time.time > _nextCalculation)
        {
            FollowPlayer();

            // If the ennemy is not visible anymore, abandon player
            if (distance < AbandonDistance && Physics.Raycast(transform.position, direction, out hit, distance))
            {
                if (hit.transform.tag != "Player")
                    Stop();
            }
        }
	}

    private void Stop()
    {
        IsFollowingPlayer = false;
        _nextCalculation = Time.time;
        _agent.SetDestination(transform.position);
        _animator.SetTrigger("idle");
    }

    private void FollowPlayer()
    {
        _nextCalculation = Time.time + RecalculationTime;
        _agent.SetDestination(Player.transform.position);
    }

    private void FindNearestPlayer()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        float minDistance = int.MaxValue;

        foreach(GameObject go in gos)
        {
            float distance = Vector3.Distance(transform.position, go.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                Player = go.transform;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Kill player
        if (collision.gameObject.tag == "Player" && !_isEating)
        {
            collision.gameObject.GetComponent<PlayerController>().Speed = 0;
            foreach(CapsuleCollider collider in collision.gameObject.GetComponents<CapsuleCollider>())
            {
                collider.enabled = false;
            }
            StartCoroutine(CorEat());
        }
    }

    private IEnumerator CorEat()
    {
        _isEating = true;

        float originalSpeed = _agent.speed;
        float originalAngular = _agent.angularSpeed;
        
        _agent.speed *= 5;
        _agent.angularSpeed = 300;

        while (_agent.remainingDistance > 0.2f)
            yield return null;

        _animator.SetTrigger("eat");
        Player.GetComponent<DeadPlayer>().Die();

        yield return new WaitForSeconds(1);
        _animator.SetTrigger("idle");
        _agent.speed = originalSpeed;
        _agent.angularSpeed = originalAngular;

        yield break;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AggroDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AbandonDistance);
    }

    public void Die()
    {
        _animator.SetTrigger("death");
        Stop();
        _agent.speed = 0;
        _agent.angularSpeed = 0;
        Destroy(gameObject, 1);
    }
}
