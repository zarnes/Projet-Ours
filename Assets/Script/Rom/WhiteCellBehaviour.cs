using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WhiteCellBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _nextCalculation;

    public float AggroDistance;
    public float AbandonDistance;

    public Transform Player;
    public float RecalculationTime;

    public bool IsFollowingPlayer;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _nextCalculation = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(Player.position, transform.position);
        Vector3 direction = Player.position - transform.position;
        RaycastHit hit;

        // If close enough, check raycast then follow player
        if (distance < AggroDistance && !IsFollowingPlayer)
        {
            if (Physics.Raycast(transform.position, direction, out hit, distance))
            {
                if (hit.transform.tag == "Player")
                {
                    IsFollowingPlayer = true;
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
    }

    private void FollowPlayer()
    {
        _nextCalculation = Time.time + RecalculationTime;
        _agent.SetDestination(Player.transform.position);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AggroDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AbandonDistance);
    }
}
