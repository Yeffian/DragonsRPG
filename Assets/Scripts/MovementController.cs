using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    
    private Vector2 _moveDir;
    private Rigidbody2D _rb;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");
        
        _animator.SetFloat("Horizontal", _moveDir.x);
        _animator.SetFloat("Vertical", _moveDir.y);
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_moveDir.x * speedMultiplier, _moveDir.y * speedMultiplier);
    }
}
