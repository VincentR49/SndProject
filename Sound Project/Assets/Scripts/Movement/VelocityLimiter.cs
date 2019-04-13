using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Attach this to a rb to limit its speed
[RequireComponent(typeof(Rigidbody))]
public class VelocityLimiter : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed = 2f;

    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (_rb.velocity.sqrMagnitude >= _maxSpeed)
        {
            LimitSpeed();
        }
    }


    private void LimitSpeed()
    {
        var speedNorm = _rb.velocity.normalized;
        //_rb.velocity = speedNorm * _maxSpeed;
        // todo
    }
}
