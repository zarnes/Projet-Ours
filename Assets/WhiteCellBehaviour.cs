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
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        
        if (distance < AggroDistance && !IsFollowingPlayer)
        {
            Ray2D ray = new Ray2D();
            //if (Physics2D.Raycast(transform.position, Player.position))
            //Debug.Log("Following");
            IsFollowingPlayer = true;
        }
            
        else if (distance > AbandonDistance && IsFollowingPlayer)
        {
            //Debug.Log("Abandon");
            IsFollowingPlayer = false;
            _nextCalculation = Time.time;
            _agent.SetDestination(transform.position);
        }

        if (IsFollowingPlayer && Time.time > _nextCalculation)
        {
            //Debug.Log("Setting destination");
            _nextCalculation = Time.time + RecalculationTime;
            _agent.SetDestination(Player.transform.position);
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AggroDistance);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AbandonDistance);
    }
}
