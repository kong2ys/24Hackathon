using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 3.0f; 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newX = startPos.x + Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = new Vector3(newX, startPos.y, startPos.z);
    }
}
