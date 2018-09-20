using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public Vector2 Direction;
    public float MinSpeed;
    public float MaxSpeed;
    public float Acceleration;

    private Dictionary<Transform, float> _entities = new Dictionary<Transform, float>();
    
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = new Vector3(Direction.x, Direction.y);
        List<Transform> entitiesKeys = new List<Transform>(_entities.Keys);
        foreach (Transform entityKey in entitiesKeys)
        {
            float speed = _entities[entityKey];
            
            Vector3 translate = direction * speed * Time.deltaTime;
            entityKey.Translate(translate);

            if (speed != MaxSpeed)
            {
                speed += Acceleration * Time.deltaTime;
                if (speed > MaxSpeed)
                    speed = MaxSpeed;

                _entities[entityKey] = speed;
            }
        }
	}
    
    //private void OnColliderEnter(Collision other)
    private void OnTriggerEnter(Collider other)
    {
        // If already exist
        if (_entities.ContainsKey(other.transform))
        {
            Debug.LogWarning(other.transform.name + " is trying to enter buoyancy zone but is already in.");
            return;
        }

        _entities.Add(other.transform, MinSpeed);
    }

    //private void OnColliderExit(Collision other)
    private void OnTriggerExit(Collider other)
    {
        // If object not found
        if (!_entities.ContainsKey(other.transform))
        {
            Debug.LogWarning(other.transform.name + " is trying to leave buoyency zone but is not inside it.");
            return;
        }

        _entities.Remove(other.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Direction.x, 0, Direction.y));
    }
}
