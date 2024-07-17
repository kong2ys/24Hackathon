using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight1 : MonoBehaviour
{
    public float speed = 5.0f;
    public float distance = 10.0f; 

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
