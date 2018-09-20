using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public List<Transform> Targets;
    public Vector3 Offset;
    public float SmoothTime = 5f;

    public float minSize = 20f;
    public float maxSize = 30f;
    public float ZoomMultiplier;

    private Vector3 _velocity;
    private Bounds _bounds;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (Targets.Count == 0)
            return;

        UpdateBounds();
        Move();
        Zoom();
    }

    private void Zoom()
    {
        float dist = (float) Math.Sqrt(_bounds.size.x * _bounds.size.x + _bounds.size.z * _bounds.size.z);
        //Debug.Log(dist);
        dist = Mathf.Clamp(dist, minSize, maxSize);
        float newZoom = Mathf.Lerp(minSize, maxSize, dist / ZoomMultiplier);
        //Debug.Log(newZoom);
        _camera.orthographicSize = newZoom;
    }

    private void Move()
    {
        Vector3 centerPoint = _bounds.center;
        Vector3 newPosition = centerPoint + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _velocity, SmoothTime);
    }

    void UpdateBounds()
    {
        _bounds = new Bounds(Targets[0].position, Vector3.zero);
        foreach(Transform target in Targets)
        {
            _bounds.Encapsulate(target.position);
        }
    }
}
