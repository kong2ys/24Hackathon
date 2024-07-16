using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerContorller : MonoBehaviour
{
    
    private Rigidbody _rd;

    public Camera mainCamera;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpPower = 5f;

    private bool _isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        _rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = mainCamera.transform.rotation;
        Move();
    }
    public float forceGravity = 50f;
    private void FixedUpdate()
    {
        _rd.AddForce(Vector3.down * forceGravity);
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;
        
        transform.position += dir * (_moveSpeed * Time.deltaTime);
        
        if (Input.GetKeyUp(KeyCode.Space) && !_isJump)
        {
            Jump();
        }
    }
    void Jump()
    {
        _isJump = true;
        _rd.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isJump = false;
        }
    }
}
