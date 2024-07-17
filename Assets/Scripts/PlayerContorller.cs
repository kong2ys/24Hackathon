using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class PlayerContorller : MonoBehaviour
{
    private Vector3 startPosition;
    private Animator anim;
    private Rigidbody _rd;

    public Camera mainCamera;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpPower = 5f;

    private bool _isJump = false;

    private bool _isMove = false;

    private bool _isRun = false;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
        _rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float forceGravity = 50f;
    private void FixedUpdate()
    {
        _rd.AddForce(Vector3.down * forceGravity);
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y = mainCamera.transform.eulerAngles.y;
        
        transform.eulerAngles = newRotation;
        
        Move();
    }
    
    private bool wasRunning = false;
    private float jumpSpeed = 0f;

    void Move()
    {
        anim.SetBool("isIdle", _isJump);

        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            
            wasRunning = Input.GetKey(KeyCode.LeftShift);
            jumpSpeed = wasRunning ? _moveSpeed * 1.5f : _moveSpeed;
            Jump();
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;

        bool isRun = Input.GetKey(KeyCode.LeftShift) && !_isJump;
        float realMoveSpeed = isRun ? _moveSpeed * 1.5f : _moveSpeed;

        anim.SetBool("isRun", isRun);
        if (!isRun)
        {
            anim.SetBool("isMove", dir != Vector3.zero);
        }

        if (_isJump)
        {
            // 유지된 속도로 이동
            transform.Translate(((Vector3.forward * vertical) + (Vector3.right * horizontal)).normalized * jumpSpeed * Time.deltaTime);
        }
        else
        {
            // 일반적인 이동
            transform.Translate(((Vector3.forward * vertical) + (Vector3.right * horizontal)).normalized * realMoveSpeed * Time.deltaTime);
        }
    }


    public void init()
    {
        transform.position = startPosition;
    }

    private float realRealMoveSpeed;
    void Jump()
    {
        anim.SetTrigger("isJump");
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