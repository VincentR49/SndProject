﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveManager : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 2f;

    private Rigidbody _rb;
    private Vector3 _direction;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _direction = Vector3.zero;
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        var deltaPosition = _moveSpeed * _direction * Time.deltaTime;
        _rb.MovePosition(_rb.transform.position + deltaPosition);
    }
}
