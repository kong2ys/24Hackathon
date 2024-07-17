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
        anim.SetBool("isIdle",_isJump);
        if (Input.GetKeyDown(KeyCode.Space) && !_isJump)
        {
            Jump();
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;
        
        bool isRun = Input.GetKey(KeyCode.LeftShift) && !_isJump ? true : false;
        float realMoveSpeed = isRun ? _moveSpeed * 1.5f : _moveSpeed;
        anim.SetBool("isRun",isRun);
        if (!isRun)
        {
            anim.SetBool("isMove",dir != Vector3.zero);    
        }
        transform.Translate(((Vector3.forward * vertical) + (Vector3.right * horizontal)).normalized * realMoveSpeed * Time.deltaTime);
    }

    public void init()
    {
        transform.position = startPosition;
    }
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