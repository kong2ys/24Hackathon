using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerContorller : MonoBehaviour
{
    private Animator anim;
    private Rigidbody _rd;

    public Camera mainCamera;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpPower = 5f;

    private bool _isJump = false;

    private bool _isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        _rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMove",_isMove);
        Debug.Log(_isMove);
        
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y = mainCamera.transform.eulerAngles.y;
        
        transform.eulerAngles = newRotation;
        
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
        if (vertical != 0 && horizontal != 0)
        {
            _isMove = true;
        }
        
        // Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;
        
        transform.Translate(((Vector3.forward * vertical) + (Vector3.right * horizontal)).normalized * _moveSpeed * Time.deltaTime);
        
        
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