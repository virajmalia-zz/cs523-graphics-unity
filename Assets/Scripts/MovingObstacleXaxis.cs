using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleXaxis : MonoBehaviour {
    private float delta = 50.0f;
    private float speed = 2.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
