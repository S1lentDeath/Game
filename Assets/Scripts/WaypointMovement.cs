using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private Vector2 _targetVelocity;
    private SpriteRenderer _renderer;
    private Transform _target;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Move();

        ChangeDirection();
    }

    private void Move()
    {
        _targetVelocity.x = Input.GetAxis("Horizontal");
         _target = _points[_currentPoint];

        if (transform.position.x < _target.position.x)
        {
            _renderer.flipX = true;
        }
        else if (transform.position.x > _target.position.x)
        {
            _renderer.flipX = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void ChangeDirection()
    {
        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
