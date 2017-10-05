using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleZaxis : MonoBehaviour {
    private float delta = 50.0f;  
    private float speed = 5.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
