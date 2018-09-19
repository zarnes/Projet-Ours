using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public Vector3 direction;
    public float MinSpeed;
    public float MaxSpeed;
    public float Acceleration;

    private Dictionary<Transform, float> _entities = new Dictionary<Transform, float>();
    	
	// Update is called once per frame
	void Update ()
    {
        foreach (KeyValuePair<Transform, float> entity in _entities)
        {
            entity.Key.Translate(direction * entity.Value * Time.deltaTime);
            _entities[entity.Key] += Acceleration * Time.deltaTime;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entering");
        // If already exist
        if (_entities.ContainsKey(other.transform))
        {
            Debug.LogWarning(other.name + " is trying to enter buoyancy zone but is already in.");
            return;
        }

        _entities.Add(transform, MinSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " leaving");

        // If object not found
        if (_entities.ContainsKey(other.transform))
        {
            Debug.LogWarning(other.name + " is trying to leave buoyency zone but is not inside it.");
            return;
        }

        _entities.Remove(other.transform);
    }
}
