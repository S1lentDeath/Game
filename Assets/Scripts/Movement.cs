using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;

    private SpriteRenderer _renderer;
    private Animator _animator;

    private float _shellRadius = 0.76f;
    private bool _onGrounded;

    private Vector2 _targetVelocity;
    private Rigidbody2D _rigidbody2D;

    private const string _grounded = "OnGround";
    private const string _move = "Move";
    private const string _horizontal = "Horizontal";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();

        Jump();

        CheckDirection();

        FixGroundSurfaces();
    }

    private void Move()
    {
        _targetVelocity.x = Input.GetAxis(_horizontal);
        _rigidbody2D.velocity = new Vector2(_targetVelocity.x * _speed, _rigidbody2D.velocity.y);

        _animator.SetFloat(_move, Mathf.Abs( _rigidbody2D.velocity.x));
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _onGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
    }

    private void FixGroundSurfaces()
    {
        _onGrounded = Physics2D.OverlapCircle(transform.position, _shellRadius, _ground);
        _animator.SetBool(_grounded, _onGrounded);
    }

    private void CheckDirection()
    {
        if(_targetVelocity.x > 0)
        {
            _renderer.flipX = false;
        }
        else if (_targetVelocity.x < 0)
        {
            _renderer.flipX = true;
        }
    }
}
